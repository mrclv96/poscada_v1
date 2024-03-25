using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Trace.ErrTrace
{
    public class CrearViewModel
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
