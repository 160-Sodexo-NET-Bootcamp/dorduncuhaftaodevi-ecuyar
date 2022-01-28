using ProcessMaker_Data.Context;
using ProcessMaker_Data.DataModel;
using ProcessMaker_Data.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.Repositories.ProcessRepository
{
    public class ProcessRepository : GenericRepository<Process_DataModel>, IProcessRepository
    {
        public ProcessRepository(ProcessMakerDbContext context) : base(context)
        {
        }
    }
}
