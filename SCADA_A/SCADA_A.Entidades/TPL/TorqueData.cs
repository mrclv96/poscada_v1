using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.TPL
{
    public class TorqueData
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        [Required]
        public string idEstacion { get; set; }
        public int IdSTA { get; set; }
        public int NumTrq { get; set; }
        public int NumTrqOK { get; set; }
        public string name { get; set; }

    }
}
