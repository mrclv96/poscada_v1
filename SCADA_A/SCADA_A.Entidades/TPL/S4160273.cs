using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.TPL
{
    public class S4160273
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        public string idEstacion { get; set; }
        public bool F_Etest { get; set; }
        public bool F_EtestAllVersion { get; set; }
        public bool F_Clipping { get; set; }
        public bool Fk_Etest { get; set; }
        public bool Fk_EtestAllVersion { get; set; }
        public bool Fk_Clipping { get; set; }
        public bool LoadScrapped { get; set; }
        public bool Sta1Scrapped { get; set; }
        public bool Sta2Scrapped { get; set; }
        public bool Sta3Scrapped { get; set; }
        public bool Sta4Scrapped { get; set; }
        public int Sta1ACycleTime { get; set; }
        public int Sta1BCycleTime { get; set; }
        public int Sta2ACycleTime { get; set; }
        public int Sta2BCycleTime { get; set; }
        public int Sta3ACycleTime { get; set; }
        public int Sta3BCycleTime { get; set; }
        public int Sta4ACycleTime { get; set; }
        public int Sta4BCycleTime { get; set; }
        public decimal EtestVAPLA1 { get; set; }
        public decimal EtestVAPLA2 { get; set; }
        public decimal EtestVAPDC1 { get; set; }
        public decimal EtestVAPDC2 { get; set; }
        public decimal EtestVAPDC3 { get; set; }
        public decimal EtestVAPDC4 { get; set; }
        public decimal EtestVACAM { get; set; }
        public int IdEtest { get; set; }
        public int ClippingCountEvent { get; set; }

    }
}
