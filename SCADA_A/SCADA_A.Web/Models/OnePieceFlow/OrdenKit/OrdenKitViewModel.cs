using SCADA_A.Entidades.Produccion;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace SCADA_A.Web.Models.OnePieceFlow.OrdenKit
{
    public class OrdenKitViewModel
    {

        public string idOrdenKit { get; set; }
        public string idOrden { get; set; }
        public int idKit { get; set; }
        public int Estatus { get; set; }

        public Int64 PKN { get; set; }
        public int JitSec { get; set; }
        public string CodigoColor { set; get; }
        public string RGBHex { get; set; }
        public string Modelo { get; set; }
        public string Version { get; set; }
        public string Color { get; set; }
        public string NombreVersion { get; set; }
        public string Variante { get; set; }
        public string Comentario { get; set; }
        public DateTime FechaYHoraCreacion { get; set;}
    }
}
