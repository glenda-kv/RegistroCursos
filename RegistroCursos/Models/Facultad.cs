using System.ComponentModel.DataAnnotations;

namespace RegistroCursos.Models
{
    public class Facultad
    {
        [Key]
        public int IdFacultad { get; set; }


        [Required(ErrorMessage = "El código de es obligatorio")]
        [StringLength(10)]
        public string CodigoFacultad { get; set; } = string.Empty;


        [Required(ErrorMessage = "El nombre es obligatorio")]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;


        [Required]
        [StringLength(100)]
        public string Decano { get; set; } = string.Empty;


        [Required]
        [StringLength(150)]
        public string Ubicacion { get; set; } = string.Empty;

        public ICollection<Carrera> Carreras { get; set; } = new List<Carrera>();

    }
}