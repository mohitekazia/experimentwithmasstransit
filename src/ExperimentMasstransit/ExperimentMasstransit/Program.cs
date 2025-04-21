
using Microsoft.EntityFrameworkCore;
using Repositories;
using System.Data.Common;

namespace ExperimentMasstransit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.{builder.Environment}.json", optional: true, reloadOnChange: true);
           
            builder.Services.AddDbContext<ExperimentMasstransitContext>((s) => { s.UseSqlServer(builder.Configuration.GetConnectionString("MassTransitDBConnection")); })
                .AddUnitOfWork<ExperimentMasstransitContext>()
                .AddCustomRepository;
            
            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}