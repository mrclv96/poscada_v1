using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Estaciones.Linea
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la línea debe ser de 3 a 50 caracteres")]
        public string Nombre { get; set; }
        [Range(0, 10, ErrorMessage = "El número de posiciones debe ser entre 0 a 10")]
        public int NoPosiciones { get; set; }
    }
}
