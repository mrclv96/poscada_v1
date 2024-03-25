using SCADA_A.Entidades.Productos;
using System;
using SCADA_A.Entidades.Colores;
using SCADA_A.Entidades.Estaciones;

namespace SCADA_A.Web.Models.Produccion.Orden
{
    public class OrdenViewModel
    {

        public string idOrden { get; set; }
        //public int idProducto { get; set; }
        public DateTime FechaYHoraCreacion { get; set; }

        public Int64 PKN { get; set; }
        public int JitSec { get; set; }

        public string CodigoColor { set; get; }
        public string Linea { set; get; }
        public int Estatus { get; set; }
        public string Comentario { set; get; }
        public string RGBHex { get; set; }
        public string Modelo { get; set; }
        public string Version { get; set; }
        public string Color { get; set; }
        public string NombreVersion { get; set; }
        public string Variante { get; set; }
        public string Secuencia { get; set; }

    }
}
