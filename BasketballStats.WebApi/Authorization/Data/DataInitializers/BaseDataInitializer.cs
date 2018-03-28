using BasketballStats.WebApi.Data.Contracts;

namespace BasketballStats.WebApi.Authorization.Data.DataInitializers
{
    public class BaseDataInitializer
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseDataInitializer(IUnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}
