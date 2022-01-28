using ProcessMaker_Data.Context;
using ProcessMaker_Data.Repositories.ProcessRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProcessMakerDbContext context;

        public IProcessRepository Processes { get; private set; }

        public UnitOfWork(ProcessMakerDbContext context)
        {
            this.context = context;

            Processes = new ProcessRepository(context);
        }

        public int Complete()
        {
            return context.SaveChanges();
        }
    }
}
