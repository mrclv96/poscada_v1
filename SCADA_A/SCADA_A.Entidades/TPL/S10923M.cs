using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCADA_A.Entidades.TPL
{
    public class S10923M
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        public string idEstacion { get; set; }
        public bool F_UpperFasciaSelected { get; set; }
        public bool F_LowerFasciaSelected { get; set; }
        public bool F_LateralCoverLHSelected { get; set; }
        public bool F_LateralCoverRHSelected { get; set; }
        public bool F_LateralTrimLHSelected { get; set; }
        public bool F_LateralTrimRHSelected { get; set; }
        public bool F_ChromeStripSelected { get; set; }
        public bool F_CenterStripSelected { get; set; }
        public bool F_TrimLowerSelected { get; set; }
        public bool F_TecBracketSelected { get; set; }
        public bool F_TechInfSelected { get; set; }
        public bool F_PushPinsSelected { get; set; }
        public bool F_ColorScanned { get; set; }
        public bool F_TecBracketPTL { get; set; }
        public bool F_TechInfPTL { get; set; }
        public bool Fk_UpperFasciaSelected { get; set; }
        public bool Fk_LowerFasciaSelected { get; set; }
        public bool Fk_LateralCoverLHSelected { get; set; }
        public bool Fk_LateralCoverRHSelected { get; set; }
        public bool Fk_LateralTrimLHSelected { get; set; }
        public bool Fk_LateralTrimRHSelected { get; set; }
        public bool Fk_ChromeStripSelected { get; set; }
        public bool Fk_CenterStripSelected { get; set; }
        public bool Fk_TrimLowerSelected { get; set; }
        public bool Fk_TecBracketSelected { get; set; }
        public bool Fk_TechInfSelected { get; set; }
        public bool Fk_PushPinsSelected { get; set; }
        public bool Fk_ColorScanned { get; set; }
        public bool Fk_TecBracketPTL { get; set; }
        public bool Fk_TechInfPTL { get; set; }

    }
}
