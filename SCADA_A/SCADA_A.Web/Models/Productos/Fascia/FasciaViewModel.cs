using System;

namespace SCADA_A.Web.Models.Productos.Fascia
{
    public class FasciaViewModel
    {
        public int idFascia { get; set; }
        public string ModeloM100Pos0 { get; set; }
        public string VersionM100Pos0 { get; set; }
        public DateTime FechaYHora { get; set; }
        public string NombreVersion { get; set; }

        public bool Estatus { get; set; }
    }
}
