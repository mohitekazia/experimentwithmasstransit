using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public static class ExperimentMasstransitServiceCollection
    {
        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection collection) where TContext:ExperimentMasstransitContext
        {
            collection.AddScoped<IUnitofWork,UnitofWork<TContext>>();
            return collection;
        }

        public static IServiceCollection AddCustomRepository<TEntity, TRepository>(this IServiceCollection services) 
            where TEntity: class
            where TRepository:class,IGenericRepository<TEntity> 
        {
            services.AddScoped<IGenericRepository<TEntity>,TRepository>();
            return services;
        }
    }
}
