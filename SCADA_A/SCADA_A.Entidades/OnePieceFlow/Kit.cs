using SCADA_A.Entidades.Estaciones;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.OnePieceFlow
{
    public class Kit
    {
        [Key]
        [Required]
        public int idKit { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El Nombre debe ser menor a 20 caracteres")]
        public string Nombre { set; get; }
        [Required]
        public bool Estatus { get; set; }
        [Required]
        public int idLinea { get; set; }

        [ForeignKey("idLinea")]
        public Linea linea { get; set; }
    }
}
