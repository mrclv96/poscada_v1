using SCADA_A.Entidades.Usuarios;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.Trace
{
    public class LogTrace
    {
        
        [Required]
        public DateTime DateAndTime { get; set; }
        [Required]
        public int idUsuario { get; set; }
        public string Table { get; set; }
        [Required]
        public string Description { get; set; }

        [ForeignKey("idUsuario")]
        public Usuario usuario { get; set; }
    }
}
