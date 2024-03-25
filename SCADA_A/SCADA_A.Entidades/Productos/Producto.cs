using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SCADA_A.Entidades.Estaciones;

namespace SCADA_A.Entidades.Productos
{
    public class Producto
    {
        [Key]
        [Required]
        public int idProducto { get; set; }
        public bool Estatus { get; set; }
        [StringLength(15)]
        public string Variante { get; set; }
        
        [Required]
        public int idSecuencia { get; set; }
        [Required]
        public int idFascia { get; set; }
        [ForeignKey("idFascia")]
        public  Fascia fascia { get; set; }
        [ForeignKey("idSecuencia")]
        public Secuencia secuencia { get; set; }


    }
}
