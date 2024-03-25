
namespace SCADA_A.Web.Models.TPL
{
    public class PunchDataViewModel
    {

        public int idProtocolo { get; set; }
        public string idEstacion { get; set; }
        public string name { get; set; }
        public decimal P_PunchSpeed { get; set; }
        public decimal P_PunchDepth { get; set; }
        public decimal P_RadiusSpeed { get; set; }
        public decimal P_RadiusDepth { get; set; }
        public int P_RadiusHoldTime { get; set; }
        public int P_WeldTime { get; set; }
        public int P_Energy { get; set; }
        public int P_Amplitude { get; set; }
        public int P_Frequency { get; set; }
        public int P_MaxPower { get; set; }
    }
}
