using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class TotalPiezasProducidas
    {
        public int SumQty { get; set; }
        public decimal TimeSumQty { get; set; }
        public decimal SumCost { get; set; }
    }
}
