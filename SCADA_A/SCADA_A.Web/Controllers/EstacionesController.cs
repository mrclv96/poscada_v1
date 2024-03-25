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
using SCADA_A.Web.Models.Estaciones.Estacion;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class EstacionesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public EstacionesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Estaciones/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<EstacionViewModel>> Listar()
        {
            var estacion = await _context.Estacions
                .Include(i => i.linea)
                .ToListAsync();

            return estacion.Select(i => new EstacionViewModel
            {
                idEstacion = i.idEstacion,
                idLinea = i.idLinea,
                Linea = i.linea.Nombre,
                Nombre = i.Nombre,
                SecuenciaPos = i.SecuenciaPos,
                Estatus = i.Estatus,
                TiempoCicloMedio_ms = i.TiempoCicloMedio_ms

            });
        }
        // GET: api/Estaciones/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var estacion = await _context.Estacions
                .Include(i => i.linea)
                .Where(c => c.Estatus == true)
                .ToListAsync();

            return estacion.Select(i => new SelectViewModel
            {
                idEstacion = i.idEstacion,
                Nombre = i.Nombre

            });
        }

        // GET: api/Estaciones/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Estacion>> Mostrar([FromRoute] string id)
        {
            var estacion = await _context.Estacions
                .Include(i => i.linea)
                .SingleOrDefaultAsync(a => a.idEstacion == id);
            //var sqp = await _context.SQP.Include(a => a.color, a => a.posicionmodelo).SingleOrDefaultAsync(a=>a.idSQP == id);

            if (estacion == null)
            {
                return NotFound();
            }

            return Ok(new EstacionViewModel
            {
                idEstacion = estacion.idEstacion,
                idLinea = estacion.idLinea,
                Linea = estacion.linea.Nombre,
                Nombre = estacion.Nombre,
                SecuenciaPos = estacion.SecuenciaPos,
                TiempoCicloMedio_ms = estacion.TiempoCicloMedio_ms
            });
        }

        // PUT: api/Estaciones/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (EstacionExists(model.idEstacion) is false)
            {
                return BadRequest();
            }

            var estacion = await _context.Estacions.FirstOrDefaultAsync(a => a.idEstacion == model.idEstacion);

            if (estacion == null)
            {
                return NotFound();
            }

            estacion.idLinea = model.idLinea;
            estacion.Nombre = model.Nombre;
            estacion.SecuenciaPos = model.SecuenciaPos;
            estacion.TiempoCicloMedio_ms = model.TiempoCicloMedio_ms;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Estacion - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Estaciones/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<Estacion>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Estacion estacion = new Estacion
            {
                idEstacion = model.idEstacion,
                idLinea = model.idLinea,
                Nombre = model.Nombre,
                SecuenciaPos = model.SecuenciaPos,
                TiempoCicloMedio_ms = model.TiempoCicloMedio_ms,
                Estatus = true,
            };

            _context.Estacions.Add(estacion);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Estacion - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Estaciones/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var estacion = await _context.Estacions.FindAsync(id);
            if (estacion == null)
            {
                return NotFound();
            }

            _context.Estacions.Remove(estacion);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Estacion - Eliminar");
                return BadRequest();
            }

            return Ok(estacion);
        }
        // PUT: api/Estaciones/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] string id)
        {

            if (EstacionExists(id) is false)
            {
                return BadRequest();
            }

            var estacion = await _context.Estacions.FirstOrDefaultAsync(a => a.idEstacion == id);

            if (estacion == null)
            {
                return NotFound();
            }

            estacion.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Estacion - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Estaciones/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] string id)
        {

            if (EstacionExists(id) is false)
            {
                return BadRequest();
            }

            var estacion = await _context.Estacions.FirstOrDefaultAsync(a => a.idEstacion == id);

            if (estacion == null)
            {
                return NotFound();
            }

            estacion.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Estacion - Desactivar");
                return BadRequest();
            }

            return Ok();
        }

        private bool EstacionExists(string id)
        {
            return _context.Estacions.Any(e => e.idEstacion == id);
        }
    }
}
