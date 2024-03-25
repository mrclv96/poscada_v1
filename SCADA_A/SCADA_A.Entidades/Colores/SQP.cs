using SCADA_A.Entidades.Productos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.Colores
{
    public class SQP
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
        public bool Estatus { get; set; }

        [ForeignKey("CodigoColor")]
        public Color color { get; set; }

        [ForeignKey("idPosicionModelo")]
        public PosicionModelo posicionmodelo { get; set; }
    }
}
