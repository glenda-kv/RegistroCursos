using Microsoft.EntityFrameworkCore;
using RegistroCursos.Models;

namespace RegistroCursos.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Facultad> Facultades { get; set; }

        public DbSet<Carrera> Carreras { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }

        public DbSet<Docente> Docentes { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public DbSet<Inscripcion> Inscripciones { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Facultad>()
                .HasIndex(f => f.CodigoFacultad)
                .IsUnique();


            modelBuilder.Entity<Carrera>()
                .HasIndex(c => c.CodigoCarrera)
                .IsUnique();

            modelBuilder.Entity<Carrera>()
                .HasOne(c => c.Facultad)
                .WithMany(f => f.Carreras)
                .HasForeignKey(c => c.IdFacultad)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Estudiante>()
                .HasIndex(e => e.NumeroMatricula)
                .IsUnique();


            modelBuilder.Entity<Estudiante>()
                .HasIndex(e => e.Correo)
                .IsUnique();

            modelBuilder.Entity<Estudiante>()
                .HasOne(e => e.Carrera)
                .WithMany(c => c.Estudiantes)
                .HasForeignKey(e => e.IdCarrera)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Docente>()
                .HasIndex(d => d.Cedula)
                .IsUnique();

            modelBuilder.Entity<Docente>()
                .HasIndex(d => d.Correo)
                .IsUnique();


            modelBuilder.Entity<Curso>()
                .HasIndex(c => c.CodigoCurso)
                .IsUnique();

            modelBuilder.Entity<Curso>()
                .HasOne(c => c.Docente)
                .WithMany(d => d.Cursos)
                .HasForeignKey(c => c.IdDocente)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<Inscripcion>()
                .HasIndex(i => new
                {
                    i.IdEstudiante,
                    i.IdCurso
                })
                .IsUnique();

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Estudiante)
                .WithMany(e => e.Inscripciones)
                .HasForeignKey(i => i.IdEstudiante)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Inscripcion>()
                .HasOne(i => i.Curso)
                .WithMany(c => c.Inscripciones)
                .HasForeignKey(i => i.IdCurso)
                .OnDelete(DeleteBehavior.Restrict);


        }

    }
}