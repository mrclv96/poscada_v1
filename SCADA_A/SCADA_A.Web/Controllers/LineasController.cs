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
using SCADA_A.Web.Models.Estaciones.Linea;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LineasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public LineasController(DbContextSCADA_A context)
        {
            _context = context;
        }
        // GET: api/Lineas/Listar
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<LineaViewModel>> Listar()
        {
            var linea = await _context.Lineas.ToListAsync();

            return linea.Select(a => new LineaViewModel
            {
                idLinea = a.idLinea,
                Nombre = a.Nombre,
                NoPosiciones = a.NoPosiciones,
                Estatus = a.Estatus,

            });
        }

        // GET: api/Lineas/Mostrar/1
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Linea>> Mostrar([FromRoute] int id)
        {
            var linea = await _context.Lineas.SingleOrDefaultAsync(a => a.idLinea == id);

            if (linea == null)
            {
                return NotFound();
            }

            return Ok(new LineaViewModel
            {
                idLinea = linea.idLinea,
                Nombre = linea.Nombre,
                NoPosiciones = linea.NoPosiciones,
                Estatus =  linea.Estatus

            });
        }
        // GET: api/Estaciones/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var linea = await _context.Lineas
                .Where(e => e.Estatus == true)
                .ToListAsync();

            return linea.Select(e => new SelectViewModel
            {
                idLinea = e.idLinea,
                Nombre = e.Nombre,
                NoPosiciones = e.NoPosiciones
            });
        }

        // PUT: api/Lineas/Actualizar
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

            if (model.idLinea < 0)
            {
                return BadRequest();
            }

            var linea = await _context.Lineas.FirstOrDefaultAsync(a => a.idLinea == model.idLinea);

            if (linea == null)
            {
                return NotFound();
            }

            linea.Nombre = model.Nombre;
            linea.NoPosiciones = model.NoPosiciones;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Linea - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Lineas/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Linea>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Linea linea = new Linea
            {
                Nombre = model.Nombre,
                NoPosiciones = model.NoPosiciones,
                Estatus = true
            };

            _context.Lineas.Add(linea);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Linea - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Lineas/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var linea = await _context.Lineas.FindAsync(id);
            if (linea == null)
            {
                return NotFound();
            }

            _context.Lineas.Remove(linea);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Linea - Eliminar");
                return BadRequest();
            }

            return Ok(linea);
        }
        // PUT: api/Lineas/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (LineaExists(id) is false)
            {
                return BadRequest();
            }

            var linea = await _context.Lineas.FirstOrDefaultAsync(a => a.idLinea == id);

            if (linea == null)
            {
                return NotFound();
            }

            linea.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Linea - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Lineas/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {


            if (LineaExists(id) is false)
            {
                return BadRequest();
            }

            var linea = await _context.Lineas.FirstOrDefaultAsync(a => a.idLinea == id);

            if (linea == null)
            {
                return NotFound();
            }

            linea.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Linea - Desactivar");
                return BadRequest();
            }

            return Ok();
        }

        private bool LineaExists(int id)
        {
            return _context.Lineas.Any(e => e.idLinea == id);
        }
    }
}
