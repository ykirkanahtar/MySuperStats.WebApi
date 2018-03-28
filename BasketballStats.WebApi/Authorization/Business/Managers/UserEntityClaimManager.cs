﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Enums;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Data.Utils;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Helper;
using BasketballStats.WebApi.Utils;
using LinqKit;

namespace BasketballStats.WebApi.Authorization.Business.Managers
{
    public class UserEntityClaimManager : BusinessManagerBase<UserEntityClaimManager, ApiRequest>, IUserEntityClaimManager
    {

        public UserEntityClaimManager(IUnitOfWork unitOfWork, ILogger<UserEntityClaimManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<UserEntityClaim> CreateAsync(UserEntityClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<UserEntityClaim>(request);

                await UniqueCheckForUserAndEntityAsync(result);

                UnitOfWork.GetRepository<UserEntityClaim, int>().Add(result);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserEntityClaim> UpdateAsync(int id, EntityClaimRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                UnitOfWork.GetRepository<UserEntityClaim, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<UserEntityClaim, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<UserEntityClaim> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<UserEntityClaim, int>().GetAsync(p => p.Id == id);
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() },
            BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<bool> UserIsAuthorizedForEntityClaimAsync(int userId, Entity entity, Crud crud)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<UserEntityClaim>();
                predicate = predicate.And(p => p.UserId == userId);
                predicate = predicate.And(p => p.Entity == entity);

                PredicateBuilderForCrud(ref predicate, crud);

                return (await UnitOfWork.GetRepository<UserEntityClaim, int>().GetAll(predicate, out _).Select(p => p).ToListAsync()).Count > 0;

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<UserEntityClaim>> GetAllByEntityAsync(Entity entity)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<UserEntityClaim>();
                predicate = predicate.And(p => p.Entity == entity);

                return new CustomEntityList<UserEntityClaim>
                {
                    EntityList = await UnitOfWork.GetRepository<UserEntityClaim, int>().GetAll(predicate, out var count).Select(p => p).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        public Task<CustomEntityList<UserEntityClaim>> GetAllByUserIdAsync(int userId)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<UserEntityClaim>();
                predicate = predicate.And(p => p.UserId == userId);

                return new CustomEntityList<UserEntityClaim>
                {
                    EntityList = await UnitOfWork.GetRepository<UserEntityClaim, int>().GetAll(predicate, out var count).Select(p => p).ToListAsync(),
                    Count = count,
                };
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckNothing, GetType().Name);
        }

        #region Validations
        private async Task UniqueCheckForUserAndEntityAsync(UserEntityClaim entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<UserEntityClaim>();
            predicate = predicate.And(p => p.UserId == entity.UserId);
            predicate = predicate.And(p => p.Entity == entity.Entity);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<UserEntityClaim, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.EntityClaim);
        }

        #endregion

        private static void PredicateBuilderForCrud(ref ExpressionStarter<UserEntityClaim> predicate, Crud crud)
        {
            switch (crud)
            {
                case Crud.Create:
                    predicate = predicate.And(p => p.CanCreate);
                    break;
                case Crud.Update:
                    predicate = predicate.And(p => p.CanUpdate);
                    break;
                case Crud.Delete:
                    predicate = predicate.And(p => p.CanDelete);
                    break;
                case Crud.Select:
                    predicate = predicate.And(p => p.CanSelect);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(crud), crud, null);
            }
        }

    }
}
