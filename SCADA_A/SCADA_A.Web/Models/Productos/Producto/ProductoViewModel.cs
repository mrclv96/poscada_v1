using SCADA_A.Entidades.Estaciones;
using System.Collections.Generic;

namespace SCADA_A.Web.Models.Productos.Producto
{
    public class ProductoViewModel
    {
        public int idProducto { get; set; }
        public int idSecuencia { get; set; }
        public int idFascia { get; set; }
        public string Nombre { get; set; }
        public string Posicion0 { get; set; }
        public string Version { get; set; }
        public string Variante { get; set; }
        public string Linea { get; set; }
        public string Secuencia { get; set; }
        public bool Estatus { get; set; }

    }
}
