using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.WebApiUtils.Business;
using CustomFramework.WebApiUtils.Contracts;
using CustomFramework.WebApiUtils.Enums;
using CustomFramework.WebApiUtils.Utils;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Enums;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public class PlayerManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IPlayerManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        private readonly IMatchGroupUserManager _matchGroupUserManager;

        public PlayerManager(IUnitOfWorkWebApi uow, ILogger<MatchGroupManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor, IMatchGroupUserManager matchGroupUserManager)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
            _matchGroupUserManager = matchGroupUserManager;
        }

        public Task<Player> CreateAsync(CreatePlayerRequest request, int? userId = null)//Misafir oyuncu ise UserId null olacak
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<Player>(request);

                if (userId != null)
                {
                    (await _uow.Users.GetByIdAsync((int)userId)).CheckRecordIsExist(nameof(User));
                    result.UserId = (int)userId;
                }

                var createUserId = userId == null ? GetLoggedInUserId() : (int)result.UserId;
                _uow.Players.Add(result, createUserId);

                await _uow.SaveChangesAsync();

                if (userId == null) //Misafir oyuncu ise karşılaşma grubuna ekleniyor
                {
                    var matchGroupPlayerRequest = new MatchGroupPlayerRequest
                    {
                        MatchGroupId = request.MatchGroupId,
                        PlayerId = result.Id,
                        RoleId = (int)RoleEnum.Guest,
                    };

                    await _matchGroupUserManager.CreateAsync(matchGroupPlayerRequest);
                }

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> UpdateAsync(int id, UpdatePlayerRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                _uow.Players.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                if(result.UserId != null)
                    throw new ArgumentException("You can delete only guest players");

                _uow.Players.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Player> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Players.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<UserDetailWithFootballStat> GetByIdWithFootballStatsAsync(int id, int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.Players.GetByIdWithFootballStatsAsync(id, matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<UserDetailWithBasketballStat> GetByIdWithBasketballStatsAsync(int id, int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.Players.GetByIdWithBasketballStatsAsync(id, matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Players.GetUserByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }        

        public Task<IList<Player>> GetAllByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () => await _uow.Players.GetAllByMatchGroupIdAsync(matchGroupId), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }
    }
}