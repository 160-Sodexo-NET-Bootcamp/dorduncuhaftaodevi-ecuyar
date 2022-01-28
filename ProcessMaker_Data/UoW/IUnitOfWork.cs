using ProcessMaker_Data.Repositories.ProcessRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.UoW
{
    public interface IUnitOfWork
    {
        IProcessRepository Processes { get; }

        int Complete();
    }
}
