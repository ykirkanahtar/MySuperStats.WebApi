using AutoMapper;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Managers
{
    public class UserClaimManager : BusinessManagerBase<UserClaimManager, ApiRequest>, IUserClaimManager
    {
        public UserClaimManager(IUnitOfWork unitOfWork, ILogger<UserClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<bool> AddUserToClaimAsync(UserClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<UserClaim>(request);

                /******************References Table Check Values****************/
                /***************************************************************/
                await BusinessUtil.GetByIntIdChecker<User, IRepository<User>>(result.UserId, UnitOfWork.GetRepository<User, int>());

                await BusinessUtil.GetByIntIdChecker<Claim, IRepository<Claim>>(result.ClaimId, UnitOfWork.GetRepository<Claim, int>());
                /***************************************************************/
                /***************************************************************/

                await UniqueCheckForUserAndClaimAsync(result);

                UnitOfWork.GetRepository<UserClaim, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<bool> RemoveUserFromClaimAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<UserClaim, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
                return true;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                return await UnitOfWork.GetRepository<UserClaim, int>().GetAll(predicate: p => p.Id == id).FirstOrDefaultAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> UserIsAuthorizedForClaimAsync(int userId, int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                return (await UnitOfWork.GetRepository<UserClaim, int>().GetAll(predicate: p => p.UserId == userId && p.ClaimId == claimId).ToListAsync()).Count > 0;

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<Claim>> GetClaimsByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<Claim>
                {
                    EntityList = await UnitOfWork.GetRepository<UserClaim, int>().GetAll(out var count, predicate: p => p.UserId == userId).Select(p => p.Claim).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<User>> GetUsersByClaimIdAsync(int claimId)
        {
            return CommonOperationAsync(async () =>
            {
                return new CustomEntityList<User>
                {
                    EntityList = await UnitOfWork.GetRepository<UserClaim, int>().GetAll(out var count, predicate: p => p.ClaimId == claimId).Select(p => p.User).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForUserAndClaimAsync(UserClaim entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<UserClaim>();
            predicate = predicate.And(p => p.UserId == entity.UserId);
            predicate = predicate.And(p => p.ClaimId == entity.ClaimId);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<UserClaim, int>().GetAll(predicate: predicate).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, GetType().Name);
        }

        #endregion

    }
}
