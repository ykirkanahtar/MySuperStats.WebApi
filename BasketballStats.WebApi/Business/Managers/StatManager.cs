using AutoMapper;
using BasketballStats.WebApi.Business.Contracts;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Models;
using BasketballStats.WebApi.RequestModels;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using BasketballStats.WebApi.Data.Utils;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace BasketballStats.WebApi.Business.Managers
{
    public class StatManager : BusinessManagerBase<StatManager, ApiRequest>, IStatManager
    {
        public StatManager(IUnitOfWork unitOfWork, ILogger<StatManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {
        }

        public Task<Stat> CreateAsync(StatRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<Stat>(request);

                await UniqueCheckForMatchIdAndTeamIdAndPlayerIdAsync(result);

                UnitOfWork.GetRepository<Stat, int>().Add(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Stat> UpdateAsync(int id, StatRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForMatchIdAndTeamIdAndPlayerIdAsync(result, id);

                UnitOfWork.GetRepository<Stat, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();

                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<Stat, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<Stat> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
                {
                    var result = await UnitOfWork.GetRepository<Stat, int>().GetAsync(p => p.Id == id);
                    return result;
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<Stat> GetByMatchIdTeamIdAndPlayerIdAsync(int matchId, int teamId, int playerId)
        {
            return CommonOperationAsync(async () =>
                {
                    var predicate = PredicateBuilder.New<Stat>();
                    predicate = predicate.And(p => p.MatchId == matchId);
                    predicate = predicate.And(p => p.TeamId == teamId);
                    predicate = predicate.And(p => p.PlayerId == playerId);

                    var result = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count).ToListAsync();

                    BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                    return result[0];
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () =>
                {
                    var predicate = PredicateBuilder.New<Stat>();
                    predicate = predicate.And(p => p.MatchId == matchId);

                    return new CustomEntityList<Stat>
                    {
                        EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                            .ToListAsync(),
                        Count = count,
                    };
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Stat>();
                predicate = predicate.And(p => p.PlayerId == playerId);

                return new CustomEntityList<Stat>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                        .Include(p => p.Match).Include(p => p.Team).Include(p => p.Player).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllByPlayerIdAndDateAsync(int playerId, DateTime startDateTime, DateTime endDateTime)
        {
            return CommonOperationAsync(async () =>
            {
                var matchPredicate = PredicateBuilder.New<Match>();
                matchPredicate = matchPredicate.And(p => p.MatchDate >= startDateTime.Date);
                matchPredicate = matchPredicate.And(p => p.MatchDate <= endDateTime.Date);

                var matchList = await UnitOfWork.GetRepository<Match, int>().GetAll(matchPredicate, out _)
                    .ToListAsync();

                var predicate = PredicateBuilder.New<Stat>();
                predicate = predicate.And(p => p.PlayerId == playerId);
                predicate = matchList.Aggregate(predicate, (current, match) => current.Or(p => p.MatchId == match.Id));

                return new CustomEntityList<Stat>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                        .ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Team>> GetAllTeamByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () =>
                {
                    var predicate = PredicateBuilder.New<Stat>();
                    predicate = predicate.And(p => p.MatchId == matchId);

                    return new CustomEntityList<Team>
                    {
                        EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                            .Select(p => p.Team).Distinct().ToListAsync(),
                        Count = count,
                    };
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Team>> GetAllTeamByMatchIdAndPlayerIdAsync(int matchId, int playerId)
        {
            return CommonOperationAsync(async () =>
                {
                    var predicate = PredicateBuilder.New<Stat>();
                    predicate = predicate.And(p => p.MatchId == matchId);
                    predicate = predicate.And(p => p.PlayerId == playerId);

                    return new CustomEntityList<Team>
                    {
                        EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                            .Select(p => p.Team).Distinct().ToListAsync(),
                        Count = count,
                    };
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }


        public Task<CustomEntityList<Player>> GetAllPlayerByMatchIdAsync(int matchId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Stat>();
                predicate = predicate.And(p => p.MatchId == matchId);

                return new CustomEntityList<Player>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                        .Select(p => p.Player).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Player>> GetAllPlayerByMatchIdAndTeamIdAsync(int matchId, int teamId)
        {
            return CommonOperationAsync(async () =>
                {
                    var predicate = PredicateBuilder.New<Stat>();
                    predicate = predicate.And(p => p.MatchId == matchId);
                    predicate = predicate.And(p => p.TeamId == teamId);

                    return new CustomEntityList<Player>
                    {
                        EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                            .Select(p => p.Player).ToListAsync(),
                        Count = count,
                    };
                }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
                BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }


        public Task<CustomEntityList<Player>> GetAllPlayerByDateAsync(DateTime startDateTime, DateTime endDateTime)
        {
            return CommonOperationAsync(async () =>
            {
                var matchPredicate = PredicateBuilder.New<Match>();
                matchPredicate = matchPredicate.And(p => p.MatchDate >= startDateTime.Date);
                matchPredicate = matchPredicate.And(p => p.MatchDate <= endDateTime.Date);

                var matchList = await UnitOfWork.GetRepository<Match, int>().GetAll(matchPredicate, out _)
                    .ToListAsync();

                var predicate = PredicateBuilder.New<Stat>();
                predicate = matchList.Aggregate(predicate, (current, match) => current.Or(p => p.MatchId == match.Id));

                return new CustomEntityList<Player>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                        .Select(p => p.Player).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Match>> GetAllMatchByPlayerIdAsync(int playerId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<Stat>();
                predicate = predicate.And(p => p.PlayerId == playerId);

                return new CustomEntityList<Match>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                        .Select(p => p.Match).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Match>> GetAllMatchByPlayerIdAndDateAsync(int playerId, DateTime startDateTime, DateTime endDateTime)
        {
            return CommonOperationAsync(async () =>
            {
                var matchPredicate = PredicateBuilder.New<Match>();
                matchPredicate = matchPredicate.And(p => p.MatchDate >= startDateTime.Date);
                matchPredicate = matchPredicate.And(p => p.MatchDate <= endDateTime.Date);

                var matchList = await UnitOfWork.GetRepository<Match, int>().GetAll(matchPredicate, out _)
                    .ToListAsync();

                var predicate = PredicateBuilder.New<Stat>();
                predicate = predicate.And(p => p.PlayerId == playerId);
                predicate = matchList.Aggregate(predicate, (current, match) => current.Or(p => p.MatchId == match.Id));

                return new CustomEntityList<Match>
                {
                    EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(predicate, out var count)
                        .Select(p => p.Match).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<CustomEntityList<Stat>> GetAllAsync()
        {
            return CommonOperationAsync(async () => new CustomEntityList<Stat>
            {
                EntityList = await UnitOfWork.GetRepository<Stat, int>().GetAll(out var count).Include(p => p.Match).Include(p => p.Team).Include(p => p.Player).ToListAsync(),
                Count = count,
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForMatchIdAndTeamIdAndPlayerIdAsync(Stat entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<Stat>();
            predicate = predicate.And(p => p.MatchId == entity.MatchId);
            predicate = predicate.And(p => p.TeamId == entity.TeamId);
            predicate = predicate.And(p => p.PlayerId == entity.PlayerId);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<Stat, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.MatchIdAndTeamIdAndPlayerId);
        }

        #endregion

    }
}
