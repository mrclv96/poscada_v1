using SCADA_A.Entidades.Estaciones;
using SCADA_A.Entidades.Produccion;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCADA_A.Entidades.OnePieceFlow
{
    public class OrdenKit
    {
        [Key]
        [Required]
        public Int64 idOrdenKit { get; set; }
        [Required]
        public Int64 idOrden { get; set; }
        [Required]
        public int idKit { get; set; }
        [Required]
        public int Estatus { get; set; }

        [ForeignKey("idOrden")]
        public Orden orden { get; set; }
        [ForeignKey("idKit")]
        public Kit kit { get; set; }

    }
}
