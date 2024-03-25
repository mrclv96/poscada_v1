using System;

namespace SCADA_A.Web.Models.OEE.Scrap
{
    public class SAPScrapVViewModel
    {
        public DateTime Pstng_DateTime { get; set; }
        public int Material { get; set; }
        public string Material_Description { get; set; }
        public Int16 MvT { get; set; }
        public Byte Item { get; set; }
        public Int64 Mat_Doc { get; set; }
        public Int16 SLoc { get; set; }
        public Int16 Reas { get; set; }
        public string Reference { get; set; }
        public string Document_Header_Text { get; set; }
        public string Plnt { get; set; }
        public string User_name { get; set; }
        public decimal Quantity_in_UnE { get; set; }
        public string EUn { get; set; }
        public string Crcy { get; set; }
        public decimal Amount_in_LC { get; set; }
    }
}
