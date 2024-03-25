using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class DistribucionCostoScrap
    {
        public string NomDefautUS { get; set; }
        public decimal JettaPAFront { get; set; }
        public decimal JettaPAGLIRear { get; set; }
        public decimal JettaPAGPRear { get; set; }
        public decimal TiguanRear { get; set; }
        public decimal TiguanPAFront { get; set; }
    }
}
