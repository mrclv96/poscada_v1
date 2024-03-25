namespace SCADA_A.Web.Models.Usuarios.Usuario
{
    public class UsuarioViewModel
    {
        public int idUsuario { get; set; }
        public int idRol { get; set; }
        public string Nombre { get; set; }
        public string Rol { get; set; }
        public byte[] PasswordHash { get; set; }
        public bool Estatus { get; set; }
    }
}
