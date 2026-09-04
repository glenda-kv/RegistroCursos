using System.ComponentModel.DataAnnotations;

namespace RegistroCursos.Models
{
    public class Carrera
    {

        [Key]
        public int IdCarrera { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoCarrera { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(1, 5)]
        public int DuracionAnios { get; set; }

        [Required]
        [StringLength(20)]
        public string Modalidad { get; set; } = string.Empty;

        [Required]
        public int IdFacultad { get; set; }

        public Facultad Facultad { get; set; } = null!;

        public ICollection<Estudiante> Estudiantes { get; set; } = new List<Estudiante>();

    }
}