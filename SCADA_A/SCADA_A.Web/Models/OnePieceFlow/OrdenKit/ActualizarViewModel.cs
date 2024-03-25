using System;
using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.OnePieceFlow.OrdenKit
{
    public class ActualizarViewModel
    {
        [Required]
        public Int64 idOrdenKit { get; set; }
        [Required]
        public int Estatus { get; set; }
    }
}
