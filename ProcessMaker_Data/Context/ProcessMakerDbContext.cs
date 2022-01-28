using Microsoft.EntityFrameworkCore;
using ProcessMaker_Data.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.Context
{
    public class ProcessMakerDbContext : DbContext, IProcessMakerDbContext
    {
        public ProcessMakerDbContext(DbContextOptions<ProcessMakerDbContext> options) : base(options)
        {

        }

        public DbSet<Process_DataModel> Processes { get; set; }
    }
}
