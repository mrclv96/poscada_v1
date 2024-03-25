using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.TPL
{
    public class S2019103
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        public string idEstacion { get; set; }
        public bool F_ScanBumper { get; set; }
        public bool F_PunchWeldPLALH { get; set; }
        public bool F_PunchWeldPDCLHO { get; set; }
        public bool F_PunchWeldPDCLHI { get; set; }
        public bool F_PunchWeldPDCRHI { get; set; }
        public bool F_PunchWeldPDCRHO { get; set; }
        public bool F_PunchWeldPLARH { get; set; }
        public bool Fk_ScanBumper { get; set; }
        public bool Fk_PunchWeldPLALH { get; set; }
        public bool Fk_PunchWeldPDCLHO { get; set; }
        public bool Fk_PunchWeldPDCLHI { get; set; }
        public bool Fk_PunchWeldPDCRHI { get; set; }
        public bool Fk_PunchWeldPDCRHO { get; set; }
        public bool Fk_PunchWeldPLARH { get; set; }

    }
}
