using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Usuarios.Usuario
{
    public class ActualizarViewModel
    {
        [Required]
        public int idUsuario { get; set; }
        [Required]
        public int idRol { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe ser mayor 3 caracteres y menor a 100")]
        public string Nombre { get; set; }
        public string Password { get; set; }
        [Required]
        public bool actPassword { get; set; }

    }
}
