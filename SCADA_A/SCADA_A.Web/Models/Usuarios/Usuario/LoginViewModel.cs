using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Usuarios.Usuario
{
    public class LoginViewModel
    {
        [Required]
        public string nombre { get; set; }
        [Required]
        public string password { get; set; }
    }
}
