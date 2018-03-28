﻿using AutoMapper;
using BasketballStats.WebApi.Authorization.Business.Contracts;
using BasketballStats.WebApi.Authorization.Models;
using BasketballStats.WebApi.Authorization.Request;
using BasketballStats.WebApi.Business;
using BasketballStats.WebApi.Contracts;
using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Data.Utils;
using BasketballStats.WebApi.Enums;
using BasketballStats.WebApi.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Authorization.Business.Managers
{
    public class ClientApplicationManager : BusinessManagerBase<ClientApplicationManager, ApiRequest>, IClientApplicationManager
    {
        public ClientApplicationManager(IUnitOfWork unitOfWork, ILogger<ClientApplicationManager> logger, IMapper mapper, IApiRequestAccessor apiRequestAccessor) : base(unitOfWork, logger, mapper, apiRequestAccessor)
        {

        }

        public Task<ClientApplication> CreateAsync(ClientApplicationRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = Mapper.Map<ClientApplication>(request);

                await UniqueCheckForClientApplicationNameAsync(result);
                await UniqueCheckForClientApplicationCodeAsync(result);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(result.ClientApplicationPassword, salt);
                result.ClientApplicationPassword = hashPassword;

                UnitOfWork.GetRepository<ClientApplication, int>().Add(result);

                CreateClientApplicationUtil(result.Id, salt);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> UpdateClientApplicationAsync(int id, ClientApplicationUpdateRequest request)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);
                Mapper.Map(request, result);

                await UniqueCheckForClientApplicationNameAsync(result, id);
                await UniqueCheckForClientApplicationCodeAsync(result, id);

                UnitOfWork.GetRepository<ClientApplication, int>().Update(result);
                await UnitOfWork.SaveChangesAsync();
                return result;

            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> UpdateClientApplicationPasswordAsync(int id, string clientApplicationPassword)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {
                var result = await GetByIdAsync(id);

                var salt = HashString.GetSalt();
                var hashPassword = HashString.Hash(clientApplicationPassword, salt);
                result.ClientApplicationPassword = hashPassword;

                UnitOfWork.GetRepository<ClientApplication, int>().Update(result);

                await UpdateClientApplicationUtilAsync(id, salt);

                await UnitOfWork.SaveChangesAsync();
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task DeleteAsync(int id)
        {
            return CommonOperationWithTransactionAsync(async () =>
            {

                var result = await GetByIdAsync(id);

                UnitOfWork.GetRepository<ClientApplication, int>().Delete(result);

                await UnitOfWork.SaveChangesAsync();
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        public Task<ClientApplication> GetByIdAsync(int id)
        {
            return CommonOperationAsync(async () =>
            {
                var result = await UnitOfWork.GetRepository<ClientApplication, int>().GetAsync(p => p.Id == id);
                return result;
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplication> GetByClientApplicationCodeAsync(string code)
        {
            return CommonOperationAsync(async () =>
            {
                var predicate = PredicateBuilder.New<ClientApplication>();
                predicate = predicate.And(p => p.ClientApplicationCode == code);

                var result = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).Select(p => p).ToListAsync();

                BusinessUtil.UniqueGenericListChecker(result, GetType().Name);
                return result[0];
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() }, BusinessUtilMethod.CheckRecordIsExist, GetType().Name);
        }

        public Task<ClientApplication> LoginAsync(string code, string password)
        {
            return CommonOperationAsync(async () =>
            {
                ClientApplication clientApplication;
                try
                {
                    clientApplication = await GetByClientApplicationCodeAsync(code);
                }
                catch (KeyNotFoundException) //Eğer code sistemde yoksa, kayıt bulunamadı yerine authentication hatası fırlatması için try - catch kullanılıyor
                {
                    throw new AuthenticationException();
                }

                var clientApplicationUtil =
                    await GetClientApplicationUtilByClientApplicationIdAsync(clientApplication.Id);

                password = HashString.Hash(password, clientApplicationUtil.SpecialValue);

                var predicate = PredicateBuilder.New<ClientApplication>();
                predicate = predicate.And(p => p.ClientApplicationCode == code);
                predicate = predicate.And(p => p.ClientApplicationPassword == password);

                var clientList = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();
                if (clientList.Count == 0) throw new AuthenticationException();
                if (clientList.Count > 1) throw new DuplicateNameException(DefaultResponseMessages.DuplicateRecordForUniqueValueError);

                return clientList[0];
            }, new BusinessBaseRequest() { MethodBase = MethodBase.GetCurrentMethod() });
        }

        #region Validations
        private async Task UniqueCheckForClientApplicationNameAsync(ClientApplication entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<ClientApplication>();
            predicate = predicate.And(p => p.ClientApplicationName == entity.ClientApplicationName);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.ClientApplicationName);
        }

        private async Task UniqueCheckForClientApplicationCodeAsync(ClientApplication entity, int? id = null)
        {
            var predicate = PredicateBuilder.New<ClientApplication>();
            predicate = predicate.And(p => p.ClientApplicationCode == entity.ClientApplicationCode);

            if (id != null)
            {
                predicate = predicate.And(p => p.Id != id);
            }

            var tempResult = await UnitOfWork.GetRepository<ClientApplication, int>().GetAll(0, ApiConstants.DefaultListCount, predicate, out var _).ToListAsync();

            BusinessUtil.CheckUniqueValue(tempResult, ResourceConstants.ClientApplicationCode);
        }

        #endregion

        #region ClientApplicationUtil
        private async Task<ClientApplicationUtil> GetClientApplicationUtilByIdAsync(int id)
        {
            return await UnitOfWork.GetRepository<ClientApplicationUtil, int>().GetAsync(p => p.Id == id);
        }

        private async Task<ClientApplicationUtil> GetClientApplicationUtilByClientApplicationIdAsync(int clientApplicationId)
        {
            var predicate = PredicateBuilder.New<ClientApplicationUtil>();
            predicate = predicate.And(p => p.ClientApplicationId == clientApplicationId);
            return await UnitOfWork.GetRepository<ClientApplicationUtil, int>().GetAsync(predicate);
        }

        private async Task UpdateClientApplicationUtilAsync(int id, string salt)
        {
            var clientApplicationUtil = await GetClientApplicationUtilByIdAsync(id);
            clientApplicationUtil.SpecialValue = salt;
            UnitOfWork.GetRepository<ClientApplicationUtil, int>().Update(clientApplicationUtil);
        }

        private void CreateClientApplicationUtil(int id, string salt)
        {
            var clientApplicationUtil = new ClientApplicationUtil()
            {
                ClientApplicationId = id,
                SpecialValue = salt,
            };

            UnitOfWork.GetRepository<ClientApplicationUtil, int>().Add(clientApplicationUtil);
        }

        #endregion
    }

}
