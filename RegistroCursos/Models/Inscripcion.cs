using System.ComponentModel.DataAnnotations;

namespace RegistroCursos.Models
{
    public class Inscripcion
    {

        [Key]
        public int IdInscripcion { get; set; }

        [Required]
        public int IdEstudiante { get; set; }
        public Estudiante? Estudiante { get; set; }

        [Required]
        public int IdCurso { get; set; }
        public Curso? Curso { get; set; }

        [Required]
        public DateTime FechaInscripcion { get; set; }

        [Required]
        [StringLength(20)]
        public string Estado { get; set; } = string.Empty;

        [Range(0, 100)]
        public decimal NotaFinal { get; set; }

    }
}