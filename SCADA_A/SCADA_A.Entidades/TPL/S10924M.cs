using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCADA_A.Entidades.TPL
{
    public class S10924M
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        public string idEstacion { get; set; }
        public bool F_UpperFasciaSelected { get; set; }
        public bool F_LowerFasciaSelected { get; set; }
        public bool F_OutterLHReflectorSelected { get; set; }
        public bool F_InnerLHReflectorSelected { get; set; }
        public bool F_OutterRHReflectorSelected { get; set; }
        public bool F_InnerRHReflectorSelected { get; set; }
        public bool F_UpperChromeBlackSelected { get; set; }
        public bool F_TecBracketSelected { get; set; }
        public bool F_CenterCoverSelected { get; set; }
        public bool F_ExhaustPipSelected { get; set; }
        public bool F_MiddleReflectorSelected { get; set; }
        public bool F_DiffuserSelected { get; set; }
        public bool F_UpperFasciaScanned { get; set; }
        public bool F_ColorScanned { get; set; }
        public bool Fk_UpperFasciaSelected { get; set; }
        public bool Fk_LowerFasciaSelected { get; set; }
        public bool Fk_OutterLHReflectorSelected { get; set; }
        public bool Fk_InnerLHReflectorSelected { get; set; }
        public bool Fk_OutterRHReflectorSelected { get; set; }
        public bool Fk_InnerRHReflectorSelected { get; set; }
        public bool Fk_UpperChromeBlackSelected { get; set; }
        public bool Fk_TecBracketSelected { get; set; }
        public bool Fk_CenterCoverSelected { get; set; }
        public bool Fk_ExhaustPipSelected { get; set; }
        public bool Fk_MiddleReflectorSelected { get; set; }
        public bool Fk_DiffuserSelected { get; set; }
        public bool Fk_UpperFasciaScanned { get; set; }
        public bool Fk_ColorScanned { get; set; }

    }
}
