using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IGenericRepository<TEntity> where TEntity:class
    {
        TEntity? Get(Expression<Func<TEntity,bool>> predicate);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity,bool>> predicate,
            Func<IQueryable<TEntity>,IOrderedQueryable<TEntity>> order,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity,object>> include
            );
        IQueryable<TResult> GetAll<TResult>(
            Expression<Func<TEntity,TResult>> selector,
            Expression<Func<TEntity, bool>> predicate,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> order,
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> include
            );
        void Update(TEntity entity);
        void Delete(TEntity entity);

        TEntity Insert(TEntity entity);

        void Insert(IList<TEntity> entities);
        void Update(IList<TEntity> entities);
        IQueryable<TEntity> FromSql(string sql);


    }
}
