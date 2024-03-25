
namespace SCADA_A.Web.Models.TPL
{
    public class S2019101ViewModel
    {

        public int idProtocolo { get; set; }
        //public string idEstacion { get; set; }
        public bool F_ScanBumper { get; set; }
        public bool F_ScanColor { get; set; }
        public bool F_PunchWeldSMRLH { get; set; }
        public bool F_PunchWeldPLALH { get; set; }
        public bool F_PunchWeldPLARH { get; set; }
        public bool F_PunchWeldSMRRH { get; set; }
        public bool F_PunchGlueCamera { get; set; }
        public bool Fk_ScanBumper { get; set; }
        public bool Fk_ScanColor { get; set; }
        public bool Fk_PunchWeldSMRLH { get; set; }
        public bool Fk_PunchWeldPLALH { get; set; }
        public bool Fk_PunchWeldPLARH { get; set; }
        public bool Fk_PunchWeldSMRRH { get; set; }
        public bool Fk_PunchGlueCamera { get; set; }
        public int P_CameraGlueTime { get; set; }
        public int P_CameraGluePressure { get; set; }
    }
}
