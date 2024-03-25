using SCADA_A.Entidades.Productos;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.Estaciones
{
    public class Secuencia
    {
        [Key]
        [Required]
        public int idSecuencia { get; set; }
        [Required]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "El flujo debe ser menor a 10 caracteres")]
        public string Flujo { get; set; }
        [Required]
        public int idLinea { get; set; }
        public bool Estatus { get; set; }

        [ForeignKey("idLinea")]
        public Linea linea { get; set; }



    }
}
