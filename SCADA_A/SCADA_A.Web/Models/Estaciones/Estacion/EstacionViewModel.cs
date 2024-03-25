namespace SCADA_A.Web.Models.Estaciones.Estacion
{
    public class EstacionViewModel
    {
        public string idEstacion { get; set; }
        public int idLinea { get; set; }
        public string Nombre { get; set; }
        public string Linea { get; set; }
        public string SecuenciaPos { get; set; }
        public bool Estatus { get; set; }
        public int TiempoCicloMedio_ms { get; set; }

    }
}
