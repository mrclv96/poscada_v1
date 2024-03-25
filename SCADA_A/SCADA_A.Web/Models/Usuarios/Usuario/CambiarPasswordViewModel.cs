using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Usuarios.Usuario
{
    public class CambiarPasswordViewModel
    {
        [Required]
        public int idUsuario { get; set; }
        public string Password { get; set; }
        [Required]
        public bool actPassword { get; set; }
    }
}
