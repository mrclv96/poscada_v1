using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace SCADA_A.Entidades.Productos
{
    public class Fascia
    {
        [Required]
        public int idFascia { get; set; }
        [Required]
        [StringLength(12, MinimumLength = 11, ErrorMessage = "El Modelo M100 Pos0 debe ser de 11 a 12 caracteres")]
        public string ModeloM100Pos0 { get; set; }
        [Required]
        [StringLength(2, MinimumLength = 1, ErrorMessage = "La Versuón M100 Pos0 debe ser de 2 caracteres")]
        public string VersionM100Pos0 { get; set; }
        [Required]
        public DateTime FechaYHora { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El nombre de la estación debe ser de 3 a 50 caracteres")]
        public string NombreVersion { get; set; }
        public bool Estatus { get; set; }

    }
}
