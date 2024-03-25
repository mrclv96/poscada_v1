using System.ComponentModel.DataAnnotations;

namespace SCADA_A.Web.Models.OnePieceFlow.KitComponentes
{
    public class ActualizarViewModel
    {
        [Required]
        public int idKitComponentes { get; set; }
        [Required]
        public int idKit { get; set; }
        [StringLength(40, MinimumLength = 3, ErrorMessage = "El CUSTOMPN debe ser menor a 40 caracteres")]
        public string NOMBRE { set; get; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "El CUSTOMPN debe ser menor a 20 caracteres")]
        public string CUSTOMPN { set; get; }
        [StringLength(1, MinimumLength = 1, ErrorMessage = "El CUSTOMPN debe ser menor un caracter")]
        public string TYPE { set; get; }
        public int POSITION { get; set; }
        public bool COLOR { get; set; }
    }
}
