namespace SCADA_A.Web.Models.Estaciones.Secuencia
{
    public class SecuenciaViewModel
    {
        public int idSecuencia { get; set; }
        public int idLinea { get; set; }
        public string linea { get; set; }
        public string Flujo { get; set; }
        public bool Estatus { get; set; }

    }
}
