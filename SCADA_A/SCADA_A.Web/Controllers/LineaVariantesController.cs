using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Estaciones;
using SCADA_A.Web.Models.Estaciones.LineaVariante;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineaVariantesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public LineaVariantesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/LineaVariantes/Listar
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<LineaVarianteViewModel>> Listar()
        {
            var lineavariante = await _context.LineaVariantes
                .Include(lv => lv.linea)
                .ToListAsync();

            return lineavariante.Select(lv => new LineaVarianteViewModel
            {
                idLineaVariante = lv.idLineaVariante,
                idLinea = lv.idLinea,
                Linea = lv.linea.Nombre,
                Nombre = lv.Nombre,
                Variante = lv.Variante,
                Estatus = lv.Estatus

            });
        }

        // GET: api/LineaVariantes/Mostrar/1
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<LineaVariante>> Mostrar([FromRoute] int id)
        {
            var lineavariante = await _context.LineaVariantes
                .Include(lv => lv.linea)
                .SingleOrDefaultAsync(lv => lv.idLineaVariante == id);

            if (lineavariante == null)
            {
                return NotFound();
            }

            return Ok(new LineaVarianteViewModel
            {
                idLineaVariante = lineavariante.idLineaVariante,
                idLinea = lineavariante.idLinea,
                Linea = lineavariante.linea.Nombre,
                Nombre = lineavariante.Nombre,
                Variante = lineavariante.Variante,
                Estatus = lineavariante.Estatus
            });
        }
        // GET: api/LineaVariantes/Select
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> Select([FromRoute] int id)
        {
            var lineavariante = await _context.LineaVariantes
                .Where(lv => lv.Estatus == true)
                .Where(lv => lv.idLinea == id)
                .ToListAsync();

            return lineavariante.Select(lv => new SelectViewModel
            {
                idLineaVariante = lv.idLineaVariante,
                Nombre = lv.Nombre,
                Variante = lv.Variante,
            });
        }

        // PUT: api/LineaVariantes/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idLineaVariante <= 0)
            {
                return BadRequest();
            }

            var lineavariante = await _context.LineaVariantes
                .FirstOrDefaultAsync(a => a.idLineaVariante == model.idLineaVariante);

            if (lineavariante == null)
            {
                return NotFound();
            }

            lineavariante.idLinea = model.idLinea;
            lineavariante.Nombre = model.Nombre;
            lineavariante.Variante = model.Variante;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "LineaVariante - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/LineaVariantes/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<LineaVariante>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            LineaVariante lineavariante = new LineaVariante
            {
                idLinea = model.idLinea,
                Nombre = model.Nombre,
                Variante = model.Variante,
                Estatus = true,
            };

            _context.LineaVariantes.Add(lineavariante);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "LineaVariante - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/LineaVariantes/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lineavariante = await _context.LineaVariantes.FindAsync(id);
            if (lineavariante == null)
            {
                return NotFound();
            }

            _context.LineaVariantes.Remove(lineavariante);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "LineaVariante - Eliminar");
                return BadRequest();
            }

            return Ok(lineavariante);
        }
        // PUT: api/LineaVariantes/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (LineaVarianteExists(id) is false)
            {
                return BadRequest();
            }

            var lineavariante = await _context.LineaVariantes.FirstOrDefaultAsync(a => a.idLineaVariante == id);

            if (lineavariante == null)
            {
                return NotFound();
            }

            lineavariante.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "LineaVariante - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/LineaVariantes/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (LineaVarianteExists(id) is false)
            {
                return BadRequest();
            }

            var lineavariante = await _context.LineaVariantes.FirstOrDefaultAsync(a => a.idLineaVariante == id);

            if (lineavariante == null)
            {
                return NotFound();
            }

            lineavariante.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "LineaVariante - Desactivar");
                return BadRequest();
            }

            return Ok();
        }
        private bool LineaVarianteExists(int id)
        {
            return _context.LineaVariantes.Any(e => e.idLineaVariante == id);
        }
    }
}
