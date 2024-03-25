using System;

namespace SCADA_A.Web.Models.Produccion.Protocolo
{
    public class ProtocoloViewModel
    {

        public int idProtocolo { get; set; }
        //public Int64 idOrden { get; set; }
        public string idEstacion { get; set; }
        public string Estacion { get; set; }
        public DateTime DateAndTimeIn { get; set; }
        public DateTime DateAndTimeFbk { get; set; }
        public int FlujoActual { get; set; }
        public Int64 PKN { get; set; }
        public int JitSec { get; set; }
        public string Linea { set; get; }
        public string Modelo { get; set; }
        public string Version { get; set; }
        public string Variante { get; set; }
        public string Color { get; set; }
        public string RGBHex { get; set; }
        public decimal TiempoCiclo { get; set; }
        public Byte EstatusMaquina { get; set; }
        public Byte EstatusCalidad { get; set; }
        public string Comentario { set; get; }


    }
}
