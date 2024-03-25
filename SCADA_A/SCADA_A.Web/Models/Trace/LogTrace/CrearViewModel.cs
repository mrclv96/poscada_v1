using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Trace.LogTrace
{
    public class CrearViewModel
    {
        [Required]
        public DateTime DateAndTime { get; set; }
        [Required]
        public int idUsuario { get; set; }
        public string Table { get; set; }
        [Required]
        public string Description { get; set; }

    }
}
