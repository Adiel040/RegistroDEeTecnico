using System.ComponentModel.DataAnnotations;

namespace RegistroDEeTecnico.Models
{
    public class Tecnicos
    {
        [Key]

        public int TecnicoId { get; set; }

        [Required(ErrorMessage = "El nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "El sueldo es requerido")]
        public float SueldoHora { get; set; }
    }
}
