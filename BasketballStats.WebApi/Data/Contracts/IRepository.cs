using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Data.Contracts
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate);

        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderExpression, bool ascending = true);

        #region GetAll

        IQueryable<TEntity> GetAll();

        IQueryable<TEntity> GetAll(out int rowCount);

        #endregion

        #region GetAllWithOrderExpression

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, object>> orderExpression, bool ascending = true);

        IQueryable<TEntity> GetAll(out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true);

        #endregion

        #region GetAllWithPredicate
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, out int rowCount);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true);

        #endregion

        #region GetAllWithSkipTake

        IQueryable<TEntity> GetAll(int skip, int take, out int rowCount, bool ascending = true);

        IQueryable<TEntity> GetAll(int skip, int take, out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true);

        #endregion

        #region GetAllWithPredicate

        IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate, out int rowCount, bool ascending = true);

        IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate, out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true);

        #endregion 

        void Add(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);
    }
}
