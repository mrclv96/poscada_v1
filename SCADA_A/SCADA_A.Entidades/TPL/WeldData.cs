using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.TPL
{
    public class WeldData
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        [Required]
        public string idEstacion { get; set; }
        [Required]
        public string name { get; set; }
        public decimal P_Setpoint { get; set; }
        public decimal P_Reached { get; set; }
        public decimal P_Pressure { get; set; }
        public int P_CoolingTime { get; set; }
        public int P_AfterCoolTime { get; set; }
        public int P_WeldTime { get; set; }
        public int P_Energy { get; set; }
        public int P_Amplitude { get; set; }
        public int P_Frequency { get; set; }
        public int P_MaxPower { get; set; }

    }
}
