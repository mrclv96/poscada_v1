using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Productos;
using SCADA_A.Web.Models.Productos.PosicionModelo;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering")]
    [Route("api/[controller]")]
    [ApiController]
    public class PosicionModelosController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public PosicionModelosController(DbContextSCADA_A context)
        {
            _context = context;
        }


        // GET: api/PosicionModelos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<PosicionModeloViewModel>> Listar()
        {
            var posicionModelo = await _context.PosicionModelos.ToListAsync();

            return posicionModelo.Select(a => new PosicionModeloViewModel
            {
                idPosicionModelo = a.idPosicionModelo,
                Posicion = a.Posicion,
                Modelo = a.Modelo,
                Cliente = a.Cliente,
                Estatus = a.Estatus,
            });
        }

        // GET: api/PosicionModelos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var posicionModelo = await _context.PosicionModelos.Where(c => c.Estatus == true).ToListAsync();

            return posicionModelo.Select(a => new SelectViewModel
            {
                idPosicionModelo = a.idPosicionModelo,
                Posicion = a.Posicion,
                Modelo = a.Modelo
            });
        }

        // GET: api/PosicionModelos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<PosicionModelo>> Mostrar([FromRoute] int id)
        {
            var posicionModelo = await _context.PosicionModelos.SingleOrDefaultAsync(a => a.idPosicionModelo == id);

            if (posicionModelo == null)
            {
                return NotFound();
            }

            return Ok(new PosicionModeloViewModel
            {
                idPosicionModelo = posicionModelo.idPosicionModelo,
                Posicion = posicionModelo.Posicion,
                Modelo = posicionModelo.Modelo,
                Cliente = posicionModelo.Cliente,
                Estatus = posicionModelo.Estatus
            });
        }

        // PUT: api/PosicionModelos/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idPosicionModelo < 0)
            {
                return BadRequest();
            }

            var posicionmodelo = await _context.PosicionModelos.FirstOrDefaultAsync(a => a.idPosicionModelo == model.idPosicionModelo);

            if (posicionmodelo == null)
            {
                return NotFound();
            }

            posicionmodelo.Modelo = model.Modelo;
            posicionmodelo.Posicion = model.Posicion;
            posicionmodelo.Cliente = model.Cliente;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "PosicionModelo - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/PosicionModelos/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PosicionModelo posicionmodelo = new PosicionModelo
            {
                Modelo = model.Modelo,
                Posicion = model.Posicion,
                Cliente = model.Cliente,
                Estatus = true
            };

            _context.PosicionModelos.Add(posicionmodelo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "PosicionModelo - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/PosicionModelos/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var posicionmodelo = await _context.PosicionModelos.FindAsync(id);
            if (posicionmodelo == null)
            {
                return NotFound();
            }

            _context.PosicionModelos.Remove(posicionmodelo);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "PosicionModelo - Eliminar");
                return BadRequest();
            }

            return Ok(posicionmodelo);
        }


        // PUT: api/PosicionModelos/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var posicionmodelo = await _context.PosicionModelos.FirstOrDefaultAsync(s => s.idPosicionModelo == id);

            if (posicionmodelo == null)
            {
                return NotFound();
            }

            posicionmodelo.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "PosicionModelo - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/PosicionModelos/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var posicionmodelo = await _context.PosicionModelos.FirstOrDefaultAsync(s => s.idPosicionModelo == id);

            if (posicionmodelo == null)
            {
                return NotFound();
            }

            posicionmodelo.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "PosicionModelo - Desactivar");
                return BadRequest();
            }

            return Ok();
        }
        private bool PosicionModeloExists(int id)
        {
            return _context.PosicionModelos.Any(e => e.idPosicionModelo == id);
        }
    }
}
