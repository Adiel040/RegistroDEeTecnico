using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RegistroDEeTecnico.Models
{
    public class Tecnicos
    {
        [Key]
        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Range(1, float.MaxValue, ErrorMessage = "El sueldo es requerido")]
        public float SueldoHora { get; set; }
        [ForeignKey("TiposTecnicos")]
        public int tipoId { get; set; }

        public TiposTecnicos tiposTecnico { get; set; }
    }
}
