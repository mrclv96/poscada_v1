using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Web.Models.Colores.SQP
{
    public class CrearViewModel
    {
        [Required]
        [Range(10000000, 99999999, ErrorMessage = "El código de color debe ser 6 caracteres")]
        public int CodigoSQP { get; set; }
        [Required]
        //[ForeignKey("CodigoColor")]
        public string CodigoColor { get; set; }
        [Required]
        //[ForeignKey("idPosicionModelo")]
        public int idPosicionModelo { get; set; }
    }
}
