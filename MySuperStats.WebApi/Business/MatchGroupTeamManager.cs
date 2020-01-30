using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using CustomFramework.BaseWebApi.Contracts.ApiContracts;
using CustomFramework.BaseWebApi.Utils.Business;
using CustomFramework.BaseWebApi.Utils.Utils;
using Microsoft.Extensions.Logging;
using MySuperStats.Contracts.Requests;
using MySuperStats.WebApi.Data;
using MySuperStats.WebApi.Models;

namespace MySuperStats.WebApi.Business
{
    public class MatchGroupTeamManager : BaseBusinessManagerWithApiRequest<ApiRequest>, IMatchGroupTeamManager
    {
        private readonly IUnitOfWorkWebApi _uow;
        public MatchGroupTeamManager(IUnitOfWorkWebApi uow, ILogger<MatchGroupTeamManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor)
            : base(logger, mapper, apiRequestAccessor)
        {
            _uow = uow;
        }

        public Task<MatchGroupTeam> CreateAsync(MatchGroupTeamRequest request)
        {
            return CommonOperationAsync(async () =>
            {
                var result = Mapper.Map<MatchGroupTeam>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                (await _uow.MatchGroups.GetByIdAsync(result.MatchGroupId)).CheckRecordIsExist(typeof(MatchGroup).Name);
                (await _uow.Teams.GetByIdAsync(result.TeamId)).CheckRecordIsExist(typeof(Team).Name);
                /***************************************************************/
                /***************************************************************/

                _uow.MatchGroupTeams.Add(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                _uow.MatchGroupTeams.Delete(result, GetLoggedInUserId());
                await _uow.SaveChangesAsync();
            }, new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<MatchGroupTeam> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupTeams.GetByIdAsync(id)
                , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }
            );
        }

        public Task<IList<MatchGroup>> GetMatchGroupsByTeamIdAsync(int teamId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupTeams.GetMatchGroupsByTeamIdAsync(teamId)
                , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }
            );
        }


        public Task<IList<Team>> GetTeamsByMatchGroupIdAsync(int matchGroupId)
        {
            return CommonOperationAsync(async () =>
                await _uow.MatchGroupTeams.GetTeamsByMatchGroupIdAsync(matchGroupId)
                , new BusinessBaseRequest { MethodBase = MethodBase.GetCurrentMethod() }
            );
        }
    }
}