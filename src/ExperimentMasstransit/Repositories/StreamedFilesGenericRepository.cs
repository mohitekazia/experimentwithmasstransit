using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    internal sealed class StreamedFilesGenericRepository:GenericRepository<StreamedFiles>,IGenericRepository<StreamedFiles>
    {
        public StreamedFilesGenericRepository(ExperimentMasstransitContext dbcontext) : base(dbcontext)
        {

        }
    }
}
