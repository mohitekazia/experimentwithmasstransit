using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal sealed class UnitofWork<TContext> : IRepositoryFactory, IUnitofWork where TContext : ExperimentMasstransitContext
    {
        private readonly TContext _context;
        private Dictionary<Type,object> _repositories= new Dictionary<Type,object>();
        public UnitofWork(TContext context) 
        { 
           this._context = context;
        }

        public int ExecuteSQLCommand(string sql, params object[] parameters)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> FromSql<TEntity>(string sql, params object[] parameters) where TEntity : class
        {
            throw new NotImplementedException();
        }

        public IGenericRepository<TEntity> GetRepository<TEntity>() where TEntity : class
        {
            var repository = _context.GetService<IGenericRepository<TEntity>>();
            if(repository != null)
            {
                return repository;
            }

            var type= typeof(TEntity);
            if (!_repositories.ContainsKey(type)){
                _repositories.TryAdd(type, new GenericRepository<TEntity>(_context));
            }

            return (IGenericRepository<TEntity>)_repositories[type];

        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
           return await _context.SaveChangesAsync();
        }
    }
}
