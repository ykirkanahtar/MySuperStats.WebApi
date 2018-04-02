using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BasketballStats.WebApi.Data.Utils;
using Microsoft.EntityFrameworkCore.Query;

namespace BasketballStats.WebApi.Data.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {

        IQueryable<TEntity> GetAll(
            Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , SkipTake skipTake = null
        );

        IQueryable<TEntity> GetAll(out int rowCount
            , Expression<Func<TEntity, bool>> predicate = null
            , Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null
            , Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include = null
            , SkipTake skipTake = null
        );

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
