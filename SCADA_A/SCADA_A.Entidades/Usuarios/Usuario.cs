using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SCADA_A.Entidades.Usuarios
{
    public  class Usuario
    {
        public int idUsuario { get; set; }
        [Required]
        public int idRol { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "El nombre debe ser mayor 3 caracteres y menor a 100")]
        public string Nombre { get; set; }
        [Required]
        public byte[] PasswordHash { get; set; }
        [Required]
        public byte[] PasswordSalt { get; set; }
        public bool Estatus { get; set; }

        [ForeignKey("idRol")]
        public Rol rol { get; set; }
    }
}
