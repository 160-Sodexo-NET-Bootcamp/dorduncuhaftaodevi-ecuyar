using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcessMaker_Data.DataModel
{
    public class Process_DataModel
    {
        [Key]
        public int Id { get; set; }
        public int RandomNumber { get; set; }
        public string RandomWord { get; set; }
        public DateTime InsertTime { get; set; }
        public bool Status { get; set; }
    }
}
