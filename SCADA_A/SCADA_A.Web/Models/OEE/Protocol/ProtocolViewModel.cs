using System;

namespace SCADA_A.Web.Models.OEE.Protocol
{
    public class ProtocolViewModel
    {
        public short idProtocol { get; set; }
        public string Nombre { get; set; }
        public string Valor { get; set; }
        public string Comentario { get; set; }
        public string tipo { get; set; }
        public bool Estatus { get; set; }
    }
}
