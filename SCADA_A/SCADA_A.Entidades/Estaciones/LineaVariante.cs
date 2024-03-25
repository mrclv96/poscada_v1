using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.Estaciones
{
    public class LineaVariante
    {
        [Key]
        [Required]
        public int idLineaVariante { get; set; }
        [Required]
        public int idLinea { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 2, ErrorMessage = "El nombre de la Variante debe ser de 2 a 15 caracteres")]
        public string Nombre { get; set; }
        public string Variante { get; set; }
        public bool Estatus { get; set; }
        [ForeignKey("idLinea")]
        public Linea linea { get; set; }

    }
}
