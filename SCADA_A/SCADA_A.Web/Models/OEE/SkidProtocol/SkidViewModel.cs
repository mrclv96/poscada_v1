using System;

namespace SCADA_A.Web.Models.OEE.SkidProtocol
{
    public class SkidViewModel
    {
        public int LabelID { get; set; }
        public string OrderName { get; set; }
        public string OrderRef { get; set; }
        public long Skid_Number { get; set; }
        public long Skid_Serial_Number { get; set; }
        public short Position { get; set; }
        public string TypeLab { get; set; }
        public string ColorLab { get; set; }
        public string PrimerLab { get; set; }
        public string ClearLab { get; set; }
        public short VariantNo { get; set; }
        public short PitchVar { get; set; }
        public short QTY1 { get; set; }
        public short QTY2 { get; set; }
        public bool PartSide1 { get; set; }
        public bool PartSide2 { get; set; }
        public bool CO2 { get; set; }
        public bool Flaming { get; set; }
        public bool Basecoat { get; set; }
        public DateTime DateAndTimeIN { get; set; }
    }
}
