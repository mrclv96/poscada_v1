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
using SCADA_A.Web.Models.Estaciones.Secuencia;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering")]
    [Route("api/[controller]")]
    [ApiController]
    public class SecuenciasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public SecuenciasController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Secuencias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SecuenciaViewModel>> Listar()
        {
            var secuencia = await _context.Secuencias
                .Include(i => i.linea)
                .ToListAsync();

            return secuencia.Select(i => new SecuenciaViewModel
            {
                idSecuencia = i.idSecuencia,
                idLinea = i.idLinea,
                linea = i.linea.Nombre,
                Flujo = i.Flujo,
                Estatus = i.Estatus

            });
        }

        // GET: api/Secuencias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Secuencia>> Mostrar([FromRoute] int id)
        {
            var secuencia = await _context.Secuencias
                .Include(a => a.linea)
                .SingleOrDefaultAsync(a => a.idSecuencia == id);
            
            if (secuencia == null)
            {
                return NotFound();
            }

            return Ok(new SecuenciaViewModel
            {
                idSecuencia = secuencia.idSecuencia,
                idLinea = secuencia.idLinea,
                linea = secuencia.linea.Nombre,
                Flujo = secuencia.Flujo,
                Estatus = secuencia.Estatus
            });
        }

        // GET: api/Secuencias/Select
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<SelectViewModel>> Select([FromRoute] int id)
        {
            var secuencia = await _context.Secuencias
                .Include(s => s.linea)
                .Where(s => s.idLinea == id)
                .Where(s => s.Estatus == true)
                .ToListAsync();

            return secuencia.Select(s => new SelectViewModel
            {
                idSecuencia = s.idSecuencia,
                Flujo = s.Flujo
            });
        }
        // PUT: api/Secuencias/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idSecuencia <= 0)
            {
                return BadRequest();
            }

            var secuencia = await _context.Secuencias.FirstOrDefaultAsync(a => a.idSecuencia == model.idSecuencia);

            if (secuencia == null)
            {
                return NotFound();
            }

            secuencia.idSecuencia = model.idSecuencia;
            secuencia.idLinea = model.idLinea;
            secuencia.Flujo = model.Flujo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Secuencia - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Secuencias/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<Secuencia>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Secuencia secuencia = new Secuencia
            {
                idLinea = model.idLinea,
                Flujo = model.Flujo,
                Estatus = true,
            };

            _context.Secuencias.Add(secuencia);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Secuencia - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Secuencias/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var secuencia = await _context.Secuencias.FindAsync(id);
            if (secuencia == null)
            {
                return NotFound();
            }

            _context.Secuencias.Remove(secuencia);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Secuencia - Eliminar");
                return BadRequest();
            }

            return Ok(secuencia);
        }
        // PUT: api/Secuencias/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (SecuenciaExists(id) is false)
            {
                return BadRequest();
            }

            var secuencia = await _context.Secuencias.FirstOrDefaultAsync(a => a.idSecuencia == id);

            if (secuencia == null)
            {
                return NotFound();
            }

            secuencia.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Secuencia - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Secuencias/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (SecuenciaExists(id) is false)
            {
                return BadRequest();
            }

            var secuencia = await _context.Secuencias.FirstOrDefaultAsync(a => a.idSecuencia == id);

            if (secuencia == null)
            {
                return NotFound();
            }

            secuencia.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Secuencia - Desactivar");
                return BadRequest();
            }

            return Ok();
        }
        private bool SecuenciaExists(int id)
        {
            return _context.Secuencias.Any(e => e.idSecuencia == id);
        }
    }
}
