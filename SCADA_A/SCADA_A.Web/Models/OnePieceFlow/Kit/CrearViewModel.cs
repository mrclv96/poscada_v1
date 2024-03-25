using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.OnePieceFlow.Kit
{
    public class CrearViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El Nombre debe ser menor a 20 caracteres")]
        public string Nombre { set; get; }
        [Required]
        public int idLinea { get; set; }
    }
}
