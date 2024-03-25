using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class Protocol
    {
        [Required]
        public Int16 idProtocol { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Comentario { get; set;}
        public string tipo { get; set; }
        public Boolean Estatus { get; set; }
    }
}
