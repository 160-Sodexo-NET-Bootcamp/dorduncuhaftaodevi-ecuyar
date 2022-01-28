using Microsoft.EntityFrameworkCore;
using ProcessMaker_Data.DataModel;

namespace ProcessMaker_Data.Context
{
    public interface IProcessMakerDbContext
    {
        DbSet<Process_DataModel> Processes { get; set; }
    }
}
