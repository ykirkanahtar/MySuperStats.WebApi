using AutoMapper;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;
using Microsoft.Extensions.Logging;
using System.Reflection;
using System.Threading.Tasks;
using System.Collections.Generic;
using CustomFramework.BaseWebApi.Utils.Business;
using CustomFramework.BaseWebApi.Utils.Enums;
using CustomFramework.BaseWebApi.Utils.Utils;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;

namespace MySuperStats.WebApi.Business
{
    public class TeamManager : BaseBusinessManagerWithApiRequest<ApiRequest>, ITeamManager
    {
        private readonly IUnitOfWorkWebApi _uow;

        public TeamManager(IUnitOfWorkWebApi uow, ILogger<TeamManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<Team> CreateAsync(TeamRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<Team>(request);

                /**************Name is unique*****************/
                /*********************************************/
                var teamNameUniqueResult =
                    await _uow.Teams.GetByNameAsync(result.TeamName);

                teamNameUniqueResult.CheckUniqueValue(nameof(result.TeamName));
                /**************Name is unique*****************/
                /*********************************************/

                _uow.Teams.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Team> UpdateAsync(int id, TeamRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                /**************Name is unique*****************/
                /*********************************************/
                var teamNameUniqueResult =
                    await _uow.Teams.GetByNameAsync(result.TeamName);

                teamNameUniqueResult.CheckUniqueValueForUpdate(result.Id, nameof(result.TeamName));
                /**************Name is unique*****************/
                /*********************************************/

                _uow.Teams.Update(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.Teams.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Team> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () => await _uow.Teams.GetByIdAsync(id), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<IList<Team>> GetAllAsync()
        {
            return CommonOperationAsync(async () => await _uow.Teams.GetAllAsync(), new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

    }
}
