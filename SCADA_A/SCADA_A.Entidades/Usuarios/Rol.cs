using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Entidades.Usuarios
{
    public class Rol
    {
        public int IdRol { get; set; }
        [Required]
        [StringLength(30, MinimumLength =3, ErrorMessage ="El nombre debe ser mayor 3 caracteres y menor a 30")]
        public string Nombre { get; set; }
        [StringLength(100)]
        public string Descripcion { get; set; }
        public bool Estatus { get; set; }

        public ICollection<Usuario> usuarios { get; set; }

    }
}
