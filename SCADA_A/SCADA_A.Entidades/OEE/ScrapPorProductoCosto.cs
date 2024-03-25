using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class ScrapPorProductoCosto
    {
        public string Product { get; set; }
        public int SumOfProductQty { get; set; }
        public decimal SumOfProductCost { get; set; }
    }
}
