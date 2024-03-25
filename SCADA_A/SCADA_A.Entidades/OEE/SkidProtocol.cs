using System;
using System.Collections.Generic;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class SkidProtocol
    {
        public Guid ProtID { get; set; }
        public Guid OrderID { get; set; }
        public Guid SkidID { get; set; }
        public int LabelID { get; set; }
        public string OrderName { get; set; }
        public string OrderRef { get; set; }
        public long Skid_Number { get; set; }
        public long Skid_Serial_Number { get; set; }
        public short Position { get; set; }
        public short TypeID { get; set; }
        public string TypeCode { get; set; }
        public string TypeLab { get; set; }
        public short ColorID { get; set; }
        public string ColorCode { get; set; }
        public string ColorLab { get; set; }
        public int ProductID { get; set; }
        public string ProductLab { get; set; }
        public short PrimerID { get; set; }
        public string PrimerCode { get; set; }
        public string PrimerLab { get; set; }
        public short ClearID { get; set; }
        public string ClearCode { get; set; }
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
        public bool? SpFlagCO21 { get; set; }
        public bool? SpFlagCO22 { get; set; }
        public bool? SpFlagFL1 { get; set; }
        public bool? SpFlagFL2 { get; set; }
        public bool? SpFlagPR1 { get; set; }
        public bool? SpFlagPR2 { get; set; }
        public bool? SpFlagBC1 { get; set; }
        public bool? SpFlagBC2 { get; set; }
        public bool? SpFlagBC3 { get; set; }
        public bool? SpFlagBC4 { get; set; }
        public bool? SpFlagBC5 { get; set; }
        public bool? SpFlagBC6 { get; set; }
        public bool? SpFlagCC1 { get; set; }
        public bool? SpFlagCC2 { get; set; }
        public bool? SpFlagCC3 { get; set; }
        public bool? SpFlagCC4 { get; set; }
        public bool? FlagR1 { get; set; }
        public bool? FlagR2 { get; set; }
        public bool? FlagR3 { get; set; }
        public bool? FlagR4 { get; set; }
        public bool? FlagR5 { get; set; }
        public bool? FlagR6 { get; set; }
        public bool? CheckSideA { get; set; }
        public bool? CheckSideB { get; set; }
        public bool? BypassAppl { get; set; }
        public bool? BypassCV { get; set; }
        public bool? BypassOnlChgCO2FL { get; set; }
        public bool? BypassOnlChgPR { get; set; }
        public bool? BypassOnlChgBC { get; set; }
        public bool? BypassOnlChgCC { get; set; }
        public double? ResinR1 { get; set; }
        public double? ResinR2 { get; set; }
        public double? ResinR3 { get; set; }
        public double? ResinR4 { get; set; }
        public double? ResinR5 { get; set; }
        public double? ResinR6 { get; set; }
        public double? HardenerR1 { get; set; }
        public double? HardenerR2 { get; set; }
        public double? HardenerR3 { get; set; }
        public double? HardenerR4 { get; set; }
        public double? Cleaning_R1 { get; set; }
        public double? Cleaning_R2 { get; set; }
        public double? Cleaning_R3 { get; set; }
        public double? Cleaning_R4 { get; set; }
        public double? Cleaning_R5 { get; set; }
        public double? Cleaning_R6 { get; set; }
        public double? ColorChg_R1 { get; set; }
        public double? ColorChg_R2 { get; set; }
        public double? ColorChg_R3 { get; set; }
        public double? ColorChg_R4 { get; set; }
        public double? ColorChg_R5 { get; set; }
        public double? ColorChg_R6 { get; set; }
        public double? CO2_R1 { get; set; }
        public double? CO2_R2 { get; set; }
        public double? TempBooth { get; set; }
        public double? HumBoothCC { get; set; }
        public double? TempOvenCC { get; set; }
        public DateTime DateAndTimeIN { get; set; }
        public DateTime? DateAndTimeFbk { get; set; }
    }
}
