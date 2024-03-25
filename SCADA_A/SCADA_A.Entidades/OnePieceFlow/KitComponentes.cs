using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SCADA_A.Entidades.OnePieceFlow
{
    public class KitComponentes
    {
        [Key]
        [Required]
        public int idKitComponentes { get; set; }
        [Required]
        public int idKit { get; set; }
        [Required]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "El CUSTOMPN debe ser menor a 40 caracteres")]
        public string NOMBRE { set; get; }
        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El CUSTOMPN debe ser menor a 20 caracteres")]
        public string CUSTOMPN { set; get; }
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El CUSTOMPN debe ser menor un caractere")]
        public string TYPE { set; get; }
        public int? POSITION { get; set; }
        public bool COLOR { get; set; }

        [ForeignKey("idKit")]
        public Kit kit { get; set; }
    }
}
