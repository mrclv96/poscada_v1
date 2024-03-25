using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Productos.Producto
{
    public class CrearViewModel
    {
        [Required]
        public int idSecuencia { get; set; }
        [Required]
        public int idFascia { get; set; }
        [StringLength(15)]
        public string Variante { get; set; }
    }
}
