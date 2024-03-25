using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.Trace
{
    public class ErrTrace
    {
        [Required]
        public DateTime DateAndTime { get; set; }
        [Required]
        public string ProcedurName { get; set; }
        [Required]
        public string ErrNumber { get; set; }
        [Required]
        public string ErrSource { get; set; }
        [Required]
        public string ErrDescription { get; set; }

    }
}
