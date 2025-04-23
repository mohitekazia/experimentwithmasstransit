using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class ExperimentMasstransitContext : DbContext
    {
        public ExperimentMasstransitContext(DbContextOptions dbContextOptions):base(dbContextOptions)
        {
        }
      public DbSet<StreamedFiles> StreamedFiles { get; set; }
    }
}
