using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Estaciones.LineaVariante
{
    public class ActualizarViewModel
    {
        [Required]
        public int idLineaVariante { get; set; }
        [Required]
        public int idLinea { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El nombre de la Variante debe ser de 2 a 15 caracteres")]
        public string Nombre { get; set; }
        public string Variante { get; set; }
    }
}
