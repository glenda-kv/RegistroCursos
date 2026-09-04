using System.ComponentModel.DataAnnotations;

namespace RegistroCursos.Models
{
    public class Curso
    {

        [Key]
        public int IdCurso { get; set; }

        [Required]
        [StringLength(10)]
        public string CodigoCurso { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [Range(1, 20)]
        public int Creditos { get; set; }

        [Required]
        public DateTime FechaInicio { get; set; }

        [Required]
        public DateTime FechaFin { get; set; }

        [Required]
        public int IdDocente { get; set; }

        public Docente Docente { get; set; } = null!;

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    }
}