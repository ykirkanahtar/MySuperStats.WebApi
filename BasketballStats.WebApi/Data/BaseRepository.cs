using BasketballStats.WebApi.Data.Contracts;
using BasketballStats.WebApi.Data.Enum;
using BasketballStats.WebApi.Data.Utils;
using LinqKit;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BasketballStats.WebApi.Data
{
    public class BaseRepository<TEntity, TKey> : IRepository<TEntity>, IDisposable
           where TEntity : BaseModel<TKey>
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;
        private bool _disposed;

        public BaseRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        #region IRepository members

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.Where(PredicateBuild(predicate)).FirstOrDefaultAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderExpression, bool ascending = true)
        {
            return await _dbSet.Where(PredicateBuild(predicate)).OrderBy(orderExpression, ascending).FirstOrDefaultAsync();
        }

        #region GetAll

        public IQueryable<TEntity> GetAll()
        {
            return GetAll(skip: null, take: null, predicate: null, orderExpression: null, calculateRowCount: false, rowCount: out var _, ascending: true);
        }

        public IQueryable<TEntity> GetAll(out int rowCount)
        {
            return GetAll(skip: null, take: null, predicate: null, orderExpression: null, calculateRowCount: true, rowCount: out rowCount, ascending: true);
        }

        #endregion

        #region GetAllWithOrderExpression

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, object>> orderExpression, bool ascending = true)
        {
            return GetAll(skip: null, take: null, predicate: null, orderExpression: orderExpression, calculateRowCount: false, rowCount: out var _, ascending: ascending);
        }


        public IQueryable<TEntity> GetAll(out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true)
        {
            return GetAll(skip: null, take: null, predicate: null, orderExpression: orderExpression, calculateRowCount: true, rowCount: out rowCount, ascending: ascending);
        }

        #endregion

        #region GetAll With Predicate

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, out int rowCount)
        {
            return GetAll(skip: null, take: null, predicate: predicate, orderExpression: null, calculateRowCount: true, rowCount: out rowCount, ascending: true);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true)
        {
            return GetAll(skip: null, take: null, predicate: predicate, orderExpression: orderExpression, calculateRowCount: true, rowCount: out rowCount, ascending: ascending);
        }

        #endregion

        #region GetAll With Skip Take

        public IQueryable<TEntity> GetAll(int skip, int take, out int rowCount, bool ascending = true)
        {
            return GetAll(skip: skip, take: take, predicate: null, orderExpression: null, calculateRowCount: true, rowCount: out rowCount, ascending: ascending);
        }

        public IQueryable<TEntity> GetAll(int skip, int take, out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true)
        {
            return GetAll(skip: skip, take: take, predicate: null, orderExpression: orderExpression, calculateRowCount: true, rowCount: out rowCount, ascending: ascending);
        }

        #endregion

        #region GetAll With Skip Take Predicate

        public IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate, out int rowCount, bool ascending = true)
        {
            return GetAll(skip: skip, take: take, predicate: predicate, orderExpression: null, calculateRowCount: true, rowCount: out rowCount, ascending: ascending);
        }

        public IQueryable<TEntity> GetAll(int skip, int take, Expression<Func<TEntity, bool>> predicate, out int rowCount, Expression<Func<TEntity, object>> orderExpression, bool ascending = true)
        {
            return GetAll(skip: skip, take: take, predicate: predicate, orderExpression: orderExpression, calculateRowCount: true, rowCount: out rowCount, ascending: ascending);
        }

        private IQueryable<TEntity> GetAll(int? skip, int? take, Expression<Func<TEntity, bool>> predicate,
            Expression<Func<TEntity, object>> orderExpression, bool calculateRowCount, out int rowCount, bool ascending)
        {
            var query = _dbSet.Where(predicate != null ? PredicateBuild(predicate) : PredicateBuild());

            rowCount = 0;
            if (calculateRowCount) rowCount = query.Count();

            query = orderExpression != null ? query.OrderBy(orderExpression, ascending) : query.OrderBy(q => q.Id, ascending);

            if (skip != null && take != null)
                query = query.Skip((int)skip).Take((int)take);

            //var sql = query.ToSql();

            return query;
        }

        #endregion

        public void Add(TEntity entity)
        {
            entity.CreateDateTime = DateTime.Now;
            entity.Status = Status.Active;
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            entity.UpdateDateTime = DateTime.Now;

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            entity.DeleteDateTime = DateTime.Now;
            entity.Status = Status.Deleted;

            _dbSet.Attach(entity);
            _dbContext.Entry(entity).State = EntityState.Modified;
        }

        #endregion

        #region IDisposable members
        ~BaseRepository()
        {
            Dispose(false);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected void Dispose(bool disposing)
        {
            if (disposing && !_disposed)
            {
                _dbContext.Dispose();
            }

            _disposed = true;
        }

        private static Expression<Func<TEntity, bool>> PredicateBuild(Expression<Func<TEntity, bool>> predicate)
        {
            return predicate.And(p => (int)p.Status == (int)Status.Active);
        }

        private static Expression<Func<TEntity, bool>> PredicateBuild()
        {
            var predicate = PredicateBuilder.New<TEntity>();
            return predicate.And(p => (int)p.Status == (int)Status.Active);
        }

        #endregion
    }
}
