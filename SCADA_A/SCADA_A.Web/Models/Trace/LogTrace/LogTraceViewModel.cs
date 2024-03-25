using System;

namespace SCADA_A.Web.Models.Trace.LogTrace
{
    public class LogTraceViewModel
    {

        public DateTime DateAndTime { get; set; }
        //public int idUsuario { get; set; }
        public string Usuario { get; set; }
        public string Table { get; set; }
        public string Description { get; set; }
    }
}
