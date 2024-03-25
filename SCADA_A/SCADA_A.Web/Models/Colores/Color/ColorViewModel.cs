using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCADA_A.Web.Models.Colores.Color
{
    public class ColorViewModel
    {
        public string CodigoColor { get; set; }
        public string Nombre { get; set; }
        public string RGBHex { get; set; }
        public bool Estatus { get; set; }
    }
}
