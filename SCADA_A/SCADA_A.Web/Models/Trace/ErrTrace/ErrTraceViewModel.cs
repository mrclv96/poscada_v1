using System;

namespace SCADA_A.Web.Models.Trace.ErrTrace
{
    public class ErrTraceViewModel
    {
        public DateTime DateAndTime { get; set; }
        public string ProcedurName { get; set; }
        public string ErrNumber { get; set; }
        public string ErrSource { get; set; }
        public string ErrDescription { get; set; }
    }
}
