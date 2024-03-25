using SCADA_A.Entidades.Estaciones;
using SCADA_A.Entidades.Productos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCADA_A.Entidades.Produccion
{
    public class Protocolo
    {
        [Required]
        public int idProtocolo { get; set; }
        [Required]
        public Int64 idOrden { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 4, ErrorMessage = "El id de la estación debe ser de 4 a 15 caracteres")]
        public string idEstacion { get; set; }
        [Required]
        public DateTime DateAndTimeIn { get; set; }
        [Required]
        public DateTime DateAndTimeFbk { get; set; }
        [Required]
        public int FlujoActual { get; set; }
        [Required]
        public decimal TiempoCiclo { get; set; }
        [Required]
        public Byte EstatusMaquina { get; set; }
        [Required]
        public Byte EstatusCalidad { get; set; }
        [StringLength(250, MinimumLength = 0)]
        public string Comentario { set; get; }

        [ForeignKey("idOrden")]
        public Orden orden { get; set; }
        [ForeignKey("idEstacion")]
        public Estacion estacion { get; set; }
    }
}
