using System.ComponentModel.DataAnnotations;

namespace RegistroDEeTecnico.Models
{
    public class TiposTecnicos
    {

        [Key]
        public int tipoId { get; set; }
        [Required(ErrorMessage = "Por favor intentalo de nuevo, debe llenr la inscripcion")]
        public string Descripcion { get; set; }
       
    }
}
