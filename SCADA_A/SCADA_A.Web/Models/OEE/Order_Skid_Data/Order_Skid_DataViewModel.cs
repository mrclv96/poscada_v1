using System;

namespace SCADA_A.Web.Models.OEE.Order_Skid_Data
{
    public class Order_Skid_DataViewModel
    {
        public DateTime DateTimeIn { get; set; }
        public Int64 Skid { get; set; }
        public string OrderName { get; set; }
        public string Referencia { get; set; }
        public string ProductLab { get; set; }
        public string Modelo { get; set; }
        public string PrimerLab { get; set; }
        public string Color { get; set; }
        public string ClearLab { get; set; }
        public bool CO2 { get; set; }
        public bool FL { get; set; }
        public bool BC { get; set; }
        public string Lado { get; set; }
        public Int16 V { get; set; }
        public Int16 PitchVar { get; set; }
        public Int16 QTY1 { get; set; }
        public Int16 QTY2 { get; set; }
        public string Status { get; set; }
        public string Comentario { get; set; }

        public Int64 labelID { get; set; }
        public string Ubicacion { get; set; }

        public string RGBHex { get; set; }
    }
}
