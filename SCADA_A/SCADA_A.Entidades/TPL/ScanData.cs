using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.TPL
{
    public class ScanData
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        [Required]
        public string idEstacion { get; set; }
        [Required]
        public int IdSTA { get; set; }
        public string name { get; set; }
        public string StringScan { get; set; }
        public string StringStep { get; set; }

    }
}
