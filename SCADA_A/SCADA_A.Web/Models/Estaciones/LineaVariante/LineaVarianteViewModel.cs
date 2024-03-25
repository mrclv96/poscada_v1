namespace SCADA_A.Web.Models.Estaciones.LineaVariante
{
    public class LineaVarianteViewModel
    {
        public int idLineaVariante { get; set; }
        public int idLinea { get; set; }
        public string Linea { get; set; }
        public string Nombre { get; set; }
        public string Variante { get; set; }
        public bool Estatus { get; set; }

    }
}
