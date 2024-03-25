using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Estaciones.Secuencia
{
    public class CrearViewModel
    {
        [Required]
        public int idLinea { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El flujo debe ser menor a 10 caracteres")]
        public string Flujo { get; set; }
        public bool Estatus { get; set; }
    }
}
