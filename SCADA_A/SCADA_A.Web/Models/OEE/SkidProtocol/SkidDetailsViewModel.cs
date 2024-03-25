namespace SCADA_A.Web.Models.OEE.SkidProtocol
{
    public class SkidDetailsViewModel
    {
        public int LabelID { get; set; }
        public short Position { get; set; }
        public bool? FlagR1 { get; set; }
        public bool? FlagR2 { get; set; }
        public bool? FlagR3 { get; set; }
        public bool? FlagR4 { get; set; }
        public bool? FlagR5 { get; set; }
        public bool? FlagR6 { get; set; }
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
    }
}
