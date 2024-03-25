using System.ComponentModel.DataAnnotations;
using System;

namespace SCADA_A.Web.Models.OnePieceFlow.OrdenKit
{
    public class CrearViewModel
    {

        [Required]
        public Int64 idOrden { get; set; }
        [Required]
        public int idKit { get; set; }
        [Required]
        public int Estatus { get; set; }
    }
}
