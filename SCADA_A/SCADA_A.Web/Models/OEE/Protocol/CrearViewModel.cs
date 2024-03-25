using System.ComponentModel.DataAnnotations;
using System;

namespace SCADA_A.Web.Models.OEE.Protocol
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(32, MinimumLength = 1, ErrorMessage = "El Nombre debe ser menor a 32 caracteres")]
        public string Nombre { get; set; }
        [StringLength(32, MinimumLength = 1, ErrorMessage = "El Valor debe ser menor a 32 caracteres")]
        public string Valor { get; set; }
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El Comentario debe ser menor a 50 caracteres")]
        public string Comentario { get; set; }
        [StringLength(32, MinimumLength = 1, ErrorMessage = "El tipo debe ser menor a 32 caracteres")]
        public string tipo { get; set; }
        public Boolean Estatus { get; set; }
    }
}
