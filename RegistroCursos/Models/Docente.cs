using System.ComponentModel.DataAnnotations;

namespace RegistroCursos.Models
{
    public class Docente
    {

        [Key]
        public int IdDocente { get; set; }

        [Required]
        [StringLength(20)]
        public string Cedula { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string Apellido { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Especialidad { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Correo { get; set; } = string.Empty;

        [StringLength(15)]
        public string Telefono { get; set; } = string.Empty;

        public ICollection<Curso> Cursos { get; set; } = new List<Curso>();

    }
}