using SCADA_A.Entidades.Estaciones;
using SCADA_A.Entidades.Produccion;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.TPL
{
    public class S2019149
    {
        //[Required]
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        //[Required]
        //[StringLength(15, MinimumLength = 4)]
        public string idEstacion { get; set; }
        public bool F_BumperScan { get; set; }
        public bool F_Picktolightsensors { get; set; }
        public bool F_LPtypeECE { get; set; }
        public bool F_LPtypeCameraSAM { get; set; }
        public bool F_LPtypeCameraECE { get; set; }
        public bool F_LPtypeCameraSWI { get; set; }
        public bool F_LPtypeECEwithNAV { get; set; }
        public bool F_LPtypeSAM { get; set; }
        public bool F_LPtypeSAMwithAV { get; set; }
        public bool F_LPtypeSchweizWithAV { get; set; }
        public bool F_LPtypePATaiwan { get; set; }
        public bool F_LPtypeRLineTaiwan { get; set; }
        public bool F_Glue { get; set; }
        public bool Fk_BumperScan { get; set; }
        public bool Fk_Picktolightsensors { get; set; }
        public bool Fk_LPtypeECE { get; set; }
        public bool Fk_LPtypeCameraSAM { get; set; }
        public bool Fk_LPtypeCameraECE { get; set; }
        public bool Fk_LPtypeCameraSWI { get; set; }
        public bool Fk_LPtypeECEwithNAV { get; set; }
        public bool Fk_LPtypeSAM { get; set; }
        public bool Fk_LPtypeSAMwithAV { get; set; }
        public bool Fk_LPtypeSchweizWithAV { get; set; }
        public bool Fk_LPtypePATaiwan { get; set; }
        public bool Fk_LPtypeRLineTaiwan { get; set; }
        public bool Fk_Glue { get; set; }
        public string P_LicensePlateScan { get; set; }
        public decimal P_GluePressure { get; set; }
        public decimal P_GlueTime { get; set; }

        //[ForeignKey("idEstacion")]
        //public Estacion estacion { get; set; }
        //[ForeignKey("idProtocolo")]
        //public Protocolo protocolo { get; set; }

    }
}
