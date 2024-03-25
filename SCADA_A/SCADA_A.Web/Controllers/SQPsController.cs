using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Colores;
using SCADA_A.Web.Models.Colores.SQP;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering")]
    [Route("api/[controller]")]
    [ApiController]
    public class SQPsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public SQPsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/SQPs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SQPViewModel>> Listar()
        {
            var sqp = await _context.SQPs
                .Include(i => i.color)
                .Include(i => i.posicionmodelo)
                .ToListAsync();

            return sqp.Select(i => new SQPViewModel
            {
                idSQP = i.idSQP,
                CodigoSQP = i.CodigoSQP,
                CodigoColor = i.CodigoColor,
                Color = i.color.Nombre,
                RGBHex = i.color.RGBHex,
                idPosicionModelo = i.idPosicionModelo,
                Posicion = i.posicionmodelo.Modelo,
                Modelo = i.posicionmodelo.Posicion,
                Estatus = i.Estatus,

            });
        }

        // GET: api/SPQs/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<SQP>> Mostrar([FromRoute] int id)
        {
            var sqp = await _context.SQPs
                .Include(a => a.color)
                .Include(a => a.posicionmodelo)
                .SingleOrDefaultAsync(a => a.idSQP == id);
            //var sqp = await _context.SQP.Include(a => a.color, a => a.posicionmodelo).SingleOrDefaultAsync(a=>a.idSQP == id);

            if (sqp == null)
            {
                return NotFound();
            }

            return Ok(new SQPViewModel
            {
                idSQP = sqp.idSQP,
                CodigoSQP = sqp.CodigoSQP,
                CodigoColor = sqp.CodigoColor,
                Color = sqp.color.Nombre,
                RGBHex = sqp.color.RGBHex,
                idPosicionModelo = sqp.idPosicionModelo,
                Posicion = sqp.posicionmodelo.Modelo,
                Modelo = sqp.posicionmodelo.Posicion,
                Estatus = sqp.Estatus,
            });
        }

        // PUT: api/SQPs/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idSQP < 0)
            {
                return BadRequest();
            }

            var sqp = await _context.SQPs.FirstOrDefaultAsync(a => a.idSQP == model.idSQP);

            if (sqp == null)
            {
                return NotFound();
            }

            sqp.CodigoSQP = model.CodigoSQP;
            sqp.CodigoColor = model.CodigoColor;
            sqp.idPosicionModelo = model.idPosicionModelo;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "SQP - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/SQPs/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (SQPExiste(model))
            {
                return BadRequest("SQP already exists.");
            }

            SQP sqp = new SQP
            {
                CodigoSQP = model.CodigoSQP,
                CodigoColor = model.CodigoColor,
                idPosicionModelo = model.idPosicionModelo,
                Estatus = true,
            };

            _context.SQPs.Add(sqp);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "SQP - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // POST: api/SQPs/Crears
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<SQP>> Crears([FromBody] List<CrearViewModel> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (CrearViewModel item in model)
            {
                if (SQPExiste(item))
                {
                    return BadRequest("SQP already exists.");
                }
            }

                foreach (CrearViewModel item in model)
            {
                SQP sqp = new SQP
                {
                    CodigoSQP = item.CodigoSQP,
                    CodigoColor = item.CodigoColor,
                    idPosicionModelo = item.idPosicionModelo,
                    Estatus = true,
                };
                _context.SQPs.Add(sqp);
            };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "SQP - Crears");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/SQPs/Activar/1
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

            var sqp = await _context.SQPs.FirstOrDefaultAsync(s => s.idSQP == id);

            if (sqp == null)
            {
                return NotFound();
            }

            sqp.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "SQP - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/SQPs/Desactivar/1
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

            var sqp = await _context.SQPs.FirstOrDefaultAsync(s => s.idSQP == id);

            if (sqp == null)
            {
                return NotFound();
            }

            sqp.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "SQP - Desactivar");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/SQPs/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sqp = await _context.SQPs.FindAsync(id);
            if (sqp == null)
            {
                return NotFound();
            }

            _context.SQPs.Remove(sqp);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "SQP - Eliminar");
                return BadRequest();
            }

            return Ok(sqp);
        }
        private bool SQPExists(int id)
        {
            return _context.SQPs.Any(e => e.idSQP == id);
        }

        private bool SQPExiste(CrearViewModel model)
        {
            return _context.SQPs.Any(s => s.CodigoColor == model.CodigoColor && s.CodigoSQP == model.CodigoSQP && s.idPosicionModelo == model.idPosicionModelo);
        }
    }
}
