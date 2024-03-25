using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SCADA_A.Entidades.OEE
{
    public class App_Colors
    {
        [Required]
        public Int16 ColorID { get; set; }
        public string ColorCode { get; set; }
        public string ColorLab { get; set; }
        public Int16 ColorFam { get; set; }
        public string ColorAuthor { get; set; }
        public string RGBHex { get; set; }
    }
}
