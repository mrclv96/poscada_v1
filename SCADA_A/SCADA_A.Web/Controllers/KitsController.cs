using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.OnePieceFlow;
using SCADA_A.Web.Models.OnePieceFlow.Kit;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class KitsController : Controller
    {
        private readonly DbContextSCADA_A _context;

        public KitsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Kits/Listar
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<KitViewModel>> Listar()
        {
            var kit = await _context.Kits
                .Include(k => k.linea)
                .ToListAsync();

            return kit.Select(k => new KitViewModel
            {
                idKit = k.idKit,
                Nombre = k.Nombre,
                Linea = k.linea.Nombre,
                Estatus = k.Estatus

            });
        }

        // GET: api/Kits/Mostrar/1
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Kit>> Mostrar([FromRoute] int id)
        {
            var kit = await _context.Kits
                .Include(k => k.linea)
                .SingleOrDefaultAsync(k => k.idKit == id);

            if (kit == null)
            {
                return NotFound();
            }

            return Ok(new KitViewModel
            {
                idKit = kit.idKit,
                Nombre = kit.Nombre,
                Linea = kit.linea.Nombre,
                Estatus = kit.Estatus

            });
        }
        // GET: api/Kits/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var kit = await _context.Kits
                .Where(k => k.Estatus == true)
                .ToListAsync();

            return kit.Select(k => new SelectViewModel
            {
                idKit = k.idKit,
                Nombre = k.Nombre,
            });
        }

        // PUT: api/Kits/Actualizar
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

            if (model.idKit < 0)
            {
                return BadRequest();
            }

            var kit = await _context.Kits
                .Include(k => k.linea)
                .FirstOrDefaultAsync(a => a.idKit == model.idKit);

            if (kit == null)
            {
                return NotFound();
            }

            kit.Nombre = model.Nombre;
            kit.idLinea = model.idLinea;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Kit - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Kits/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Kit>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Kit kit = new Kit
            {
                Nombre = model.Nombre,
                idLinea = model.idLinea,
                Estatus = true
            };

            _context.Kits.Add(kit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Kit - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Kits/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var kit = await _context.Kits.FindAsync(id);
            if (kit == null)
            {
                return NotFound();
            }

            _context.Kits.Remove(kit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Kit - Eliminar");
                return BadRequest();
            }

            return Ok(kit);
        }
        // PUT: api/Kits/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (KitExists(id) is false)
            {
                return BadRequest();
            }

            var kit = await _context.Kits.FirstOrDefaultAsync(a => a.idKit == id);

            if (kit == null)
            {
                return NotFound();
            }

            kit.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Kit - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Kits/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {


            if (KitExists(id) is false)
            {
                return BadRequest();
            }

            var kit = await _context.Kits.FirstOrDefaultAsync(a => a.idKit == id);

            if (kit == null)
            {
                return NotFound();
            }

            kit.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Kit - Desactivar");
                return BadRequest();
            }

            return Ok();
        }

        private bool KitExists(int id)
        {
            return _context.Kits.Any(e => e.idKit == id);
        }
    }
}
