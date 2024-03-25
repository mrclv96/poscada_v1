using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Colores.SQP
{
    public class ActualizarViewModel
    {
        [Required]
        public int idSQP { get; set; }
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "El código de color debe ser 6 caracteres")]
        public int CodigoSQP { get; set; }
        [Required]
        public string CodigoColor { get; set; }
        [Required]
        public int idPosicionModelo { get; set; }

    }
}
