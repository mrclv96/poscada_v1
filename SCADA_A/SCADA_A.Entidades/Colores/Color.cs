using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace SCADA_A.Entidades.Colores
{
    public class Color
    {
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código de color debe ser 3 caracteres")]
        public string CodigoColor { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El Color debe llevar un nombre")]
        public string Nombre { get; set; }

        [StringLength(6, MinimumLength = 6, ErrorMessage = "El código de RGB de color deber ser 6 digitos en hexadcimal ")]
        public string RGBHex { get; set; }

        public bool Estatus { get; set; }

        public ICollection<SQP> sqps { get; set; }
        
    }
}
