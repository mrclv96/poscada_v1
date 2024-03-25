using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.OEE
{
    public class App_Types
    {
        [Required]
        public Int16 TypeID { get; set; }
        public string TypeCode { get; set; }
        public string TypeLab { get; set; }
        public Int16 TypePartNb1 { get; set; }
        public Int16 TypePartNb2 { get; set; }
        public string TypeAuthor { get; set; }
        public bool TypeStatus { get; set; }
    }
}
