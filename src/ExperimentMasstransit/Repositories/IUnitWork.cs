using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal interface IUnitofWork
    {
        int Save();
        Task<int> SaveAsync();

        int ExecuteSQLCommand(string sql,params object[] parameters);

        IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity:class;

        IGenericRepository<TEntity>  GetRepository<TEntity>() where TEntity:class;
    }
}
