using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RegistroCursos.Data;
using RegistroCursos.Models;

namespace RegistroCursos.Controllers
{
    public class InscripcionController : Controller
    {

        private readonly ApplicationDbContext _context;


        public InscripcionController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            var inscripciones = await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .OrderBy(i => i.IdInscripcion)
                .ToListAsync();


            return View(inscripciones);

        }

        public async Task<IActionResult> Details(int id)
        {

            var inscripcion = await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .FirstOrDefaultAsync(i => i.IdInscripcion == id);



            if (inscripcion == null)
            {
                return NotFound();
            }


            return View(inscripcion);

        }

        [HttpGet]
        public IActionResult Create()
        {

            CargarCombos();


            var inscripcion = new Inscripcion();

            inscripcion.FechaInscripcion = DateTime.UtcNow;

            inscripcion.Estado = "Activo";


            return View(inscripcion);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Inscripcion inscripcion)
        {


            inscripcion.FechaInscripcion = DateTime.SpecifyKind(
                inscripcion.FechaInscripcion,
                DateTimeKind.Utc
            );



            if (inscripcion.IdEstudiante == 0)
            {
                ModelState.AddModelError(
                    "",
                    "Debe seleccionar un estudiante");
            }



            if (inscripcion.IdCurso == 0)
            {
                ModelState.AddModelError(
                    "",
                    "Debe seleccionar un curso");
            }



            if (ModelState.IsValid)
            {

                _context.Inscripciones.Add(inscripcion);


                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }



            CargarCombos();


            return View(inscripcion);

        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {

            var inscripcion =
                await _context.Inscripciones.FindAsync(id);



            if (inscripcion == null)
            {
                return NotFound();
            }


            CargarCombos();


            return View(inscripcion);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Inscripcion inscripcion)
        {


            inscripcion.FechaInscripcion = DateTime.SpecifyKind(
                inscripcion.FechaInscripcion,
                DateTimeKind.Utc
            );

            if (ModelState.IsValid)
            {

                _context.Inscripciones.Update(inscripcion);


                await _context.SaveChangesAsync();


                return RedirectToAction(nameof(Index));

            }

            CargarCombos();


            return View(inscripcion);

        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {


            var inscripcion = await _context.Inscripciones
                .Include(i => i.Estudiante)
                .Include(i => i.Curso)
                .FirstOrDefaultAsync(i => i.IdInscripcion == id);



            if (inscripcion == null)
            {
                return NotFound();
            }



            return View(inscripcion);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int IdInscripcion)
        {


            var inscripcion =
                await _context.Inscripciones.FindAsync(IdInscripcion);



            if (inscripcion != null)
            {

                _context.Inscripciones.Remove(inscripcion);


                await _context.SaveChangesAsync();

            }


            return RedirectToAction(nameof(Index));

        }

        private void CargarCombos()
        {


            ViewBag.Estudiantes = new SelectList(
                _context.Estudiantes
                .Select(e => new
                {
                    e.IdEstudiante,
                    NombreCompleto = e.Nombre + " " + e.Apellido

                }),
                "IdEstudiante",
                "NombreCompleto"
            );

            ViewBag.Cursos = new SelectList(
                _context.Cursos,
                "IdCurso",
                "Nombre"
            );


        }


    }
}