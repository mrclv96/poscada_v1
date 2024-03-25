using System;

namespace SCADA_A.Web.Models.OEE.App_Types
{
    public class App_TypesViewModel
    {
        public short TypeID { get; set; }
        public string TypeCode { get; set; }
        public string TypeLab { get; set; }
        public short TypePartNb1 { get; set; }
        public short TypePartNb2 { get; set; }
        public string TypeAuthor { get; set; }
        public bool TypeStatus { get; set; }
    }
}
