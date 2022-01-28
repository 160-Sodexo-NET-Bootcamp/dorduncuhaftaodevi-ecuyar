using System;

namespace Entity
{
    public class ProcessDto
    {
        public int Id { get; set; }
        public int RandomNumber { get; set; }
        public string RandomWord { get; set; }
        public DateTime InsertTime { get; set; }
        public bool Status { get; set; }
    }
}
