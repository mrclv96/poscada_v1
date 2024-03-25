using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCADA_A.Entidades.TPL
{
    public class S10921M
    {
        public int id { get; set; }
        [Required]
        public int idProtocolo { get; set; }
        public string idEstacion { get; set; }
        public bool F_UpperFasciaSelected { get; set; }
        public bool F_SpoilerSelected { get; set; }
        public bool F_UpperChromeSelected { get; set; }
        public bool F_MiddleReflectorSelected { get; set; }
        public bool F_ExhaustPipeFinisherSelected { get; set; }
        public bool F_DiffuserSelected { get; set; }
        public bool F_TecBracketSelected { get; set; }
        public bool F_LHOutReflectorSelected { get; set; }
        public bool F_LHInnReflectorSelected { get; set; }
        public bool F_RHOutReflectorSelected { get; set; }
        public bool F_RHInnReflectorSelected { get; set; }
        public bool F_UpperFasciaScanned { get; set; }
        public bool F_SpoilerScanned { get; set; }
        public bool F_ColorScanned { get; set; }
        public bool Fk_UpperFasciaSelected { get; set; }
        public bool Fk_SpoilerSelected { get; set; }
        public bool Fk_UpperChromeSelected { get; set; }
        public bool Fk_MiddleReflectorSelected { get; set; }
        public bool Fk_ExhaustPipeFinisherSelected { get; set; }
        public bool Fk_DiffuserSelected { get; set; }
        public bool Fk_TecBracketSelected { get; set; }
        public bool Fk_LHOutReflectorSelected { get; set; }
        public bool Fk_LHInnReflectorSelected { get; set; }
        public bool Fk_RHOutReflectorSelected { get; set; }
        public bool Fk_RHInnReflectorSelected { get; set; }
        public bool Fk_UpperFasciaScanned { get; set; }
        public bool Fk_SpoilerScanned { get; set; }
        public bool Fk_ColorScanned { get; set; }


    }
}
