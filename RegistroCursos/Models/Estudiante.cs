using System.ComponentModel.DataAnnotations;

namespace RegistroCursos.Models
{
    public class Estudiante
    {

        [Key]
        public int IdEstudiante { get; set; }

        [Required]
        [StringLength(15)]
        public string NumeroMatricula { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [StringLength(15)]
        public string Telefono { get; set; } = string.Empty;

        [Required]
        public DateTime FechaNacimiento { get; set; }

        [Required]
        public int IdCarrera { get; set; }

        public Carrera Carrera { get; set; } = null!;

        public ICollection<Inscripcion> Inscripciones { get; set; } = new List<Inscripcion>();

    }
}