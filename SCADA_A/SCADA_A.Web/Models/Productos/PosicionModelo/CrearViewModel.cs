using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Productos.PosicionModelo
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "La posición debe ser entre 3 a 20 caracteres")]
        public string Posicion { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El modelo debe ser entre 3 a 50 caracteres")]
        public string Modelo { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "El cliente debe ser entre 2 a 20 caracteres")]
        public string Cliente { get; set; }
    }
}
