using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class ProductCostV
    {
        [Required]
        public int MaterialId { get; set; }
        public string Plant { get; set; }
        public string ValType { get; set; }
        public string MaterialDescription { get; set; }
        public string MTyp { get; set; }
        public string MatlGroup { get; set; }
        public string BUn { get; set; }
        public string PGr { get; set; }
        public string ABC { get; set; }
        public string Typ { get; set; }
        public int ValCl { get; set; }
        public string Prc { get; set; }
        public string Created { get; set; }
        public DateTime LastChg { get; set; }
        public decimal Price { get; set; }
        public string Crcy { get; set; }
        public decimal per { get; set; }
        public decimal UnPrice { get; set; }

    }
}
