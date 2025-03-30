using Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal sealed class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly ExperimentMasstransitContext _experimentMasstransitContext;
        private readonly DbSet<TEntity> _dbSet;
        public GenericRepository(ExperimentMasstransitContext experimentMasstransitContext)
        {
            this._experimentMasstransitContext = experimentMasstransitContext ?? throw new ArgumentNullException();
            this._dbSet = experimentMasstransitContext.Set<TEntity>();

        }
        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
        }

        public IQueryable<TEntity> FromSql(string sql)
        {
            throw new NotImplementedException();
        }

        public TEntity? Get(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.FirstOrDefault(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate,
                                          Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order,
                                          Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            IQueryable<TEntity> allEntities = _dbSet;
            if (predicate is not null)
                allEntities = allEntities.Where(predicate);

            if (include is not null)
                allEntities = include(allEntities);

            if (order is not null)
                return order(allEntities);
            else
                return allEntities;

        }

        public IQueryable<TResult> GetAll<TResult>(Expression<Func<TEntity, TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>,
                IOrderedQueryable<TEntity>> order,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include)
        {
            IQueryable<TEntity> allEntities = _dbSet;
            if (predicate is not null)
                allEntities = allEntities.Where(predicate);

            if (include is not null)
                allEntities = include(allEntities);

            if (order is not null)
                allEntities = order(allEntities);

            return allEntities.Select(selector);
        }

        public TEntity Insert(TEntity entity)
        {
            return _dbSet.Add(entity).Entity;
        }

        public void Insert(IList<TEntity> entities)
        {
             _dbSet.AddRange(entities);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
        }

        public void Update(IList<TEntity> entities)
        {
            _dbSet.UpdateRange(entities);
        }

        public void Delete(object id)
        {

        }
    }

    

    

}
