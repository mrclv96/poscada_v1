using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.OEE
{
    public class ScrapPorModelo
    {
        public string Part { get; set; }
        public int SumOfPartQty { get; set; }
        public decimal TimeSumOfPartQty { get; set; }
    }
}
