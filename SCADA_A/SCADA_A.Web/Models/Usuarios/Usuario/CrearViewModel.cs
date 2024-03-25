using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.Usuarios.Usuario
{
    public class CrearViewModel
    {
        [Required]
        public int idRol { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe ser mayor 3 caracteres y menor a 100")]
        public string Nombre { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
