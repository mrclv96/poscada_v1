using SCADA_A.Entidades.Colores;
using SCADA_A.Entidades.Productos;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.Produccion
{
    public class Orden
    {
        [Required]
        public Int64 idOrden { get; set; }
        [Required]
        public int idProducto { get; set; }
        [Required]
        public DateTime FechaYHoraCreacion { get; set; }
        [Required]
        public Int64 PKN { get; set; }
        [Required]
        public int JitSec { get; set; }
        [Required]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El código de color debe ser 3 caracteres")]
        public string CodigoColor { set; get; }
        [Required]
        public int Estatus { get; set; }
        [StringLength(250, MinimumLength = 0)]
        public string Comentario { set; get; }
        [StringLength(15)]
        public string Variante { get; set; }

        [ForeignKey("idProducto")]
        public Producto producto { get; set; }
        [ForeignKey("CodigoColor")]
        public Color color { get; set; }

    }
}
