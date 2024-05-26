using System.ComponentModel.DataAnnotations;

namespace RegistroDEeTecnico.Models
{
    public class IncentivosTecnicos
    {

        [Key]
        public int IncentivoId { get; set; }
        public DateTime Fecha { get; set; }
        public int TecnicoId { get; set; }

        [Required (ErrorMessage = "El campo descripcion es obligatorio")]
        public string? Descripcion { get; set; }
        
        public int CantidadServicios { get; set; }
        public decimal Monto { get; set; }
    }
}
