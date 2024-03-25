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
using SCADA_A.Web.Models.OnePieceFlow.KitComponentes;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class KitComponentesController : Controller
    {
        private readonly DbContextSCADA_A _context;

        public KitComponentesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/KitComponentes/Listar
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<KitComponentesViewModel>> Listar()
        {
            var kitcomponents = await _context.KitComponentess
                .Include(k => k.kit)
                .ToListAsync();

            return kitcomponents.Select(k => new KitComponentesViewModel
            {
                idKitComponentes = k.idKitComponentes,
                NOMBRE = k.NOMBRE,
                CUSTOMPN = k.CUSTOMPN,
                TYPE = k.TYPE,
                POSITION = k.POSITION,
                COLOR = k.COLOR,
                Kit = k.kit.Nombre

            });
        }
        // GET: api/KitComponentes/Mostrar/1
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<KitComponentes>> Mostrar([FromRoute] int id)
        {
            var kitcomponents = await _context.KitComponentess
                .Include(k => k.kit)
                .SingleOrDefaultAsync(k => k.idKitComponentes == id);

            if (kitcomponents == null)
            {
                return NotFound();
            }

            return Ok(new KitComponentesViewModel
            {
                idKitComponentes = kitcomponents.idKitComponentes,
                NOMBRE = kitcomponents.NOMBRE,
                CUSTOMPN = kitcomponents.CUSTOMPN,
                TYPE = kitcomponents.TYPE,
                POSITION = kitcomponents.POSITION,
                COLOR = kitcomponents.COLOR,
                Kit = kitcomponents.kit.Nombre,

            });
        }
        // GET: api/KitComponentes/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var kitcomponents = await _context.KitComponentess
                .Where(k => k.kit.Estatus == true)
                .ToListAsync();

            return kitcomponents.Select(k => new SelectViewModel
            {
                idKit = k.idKit,
                NOMBRE = k.NOMBRE,
                CUSTOMPN = k.CUSTOMPN,
                TYPE = k.TYPE,
                POSITION = k.POSITION,
                COLOR = k.COLOR,
            });
        }
        // PUT: api/KitComponentes/Actualizar
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

            if (model.idKitComponentes < 0)
            {
                return BadRequest();
            }

            var kitcomponents = await _context.KitComponentess.FirstOrDefaultAsync(a => a.idKitComponentes == model.idKitComponentes);

            if (kitcomponents == null)
            {
                return NotFound();
            }

            kitcomponents.NOMBRE = model.NOMBRE;
            kitcomponents.CUSTOMPN = model.CUSTOMPN;
            kitcomponents.TYPE = model.TYPE;
            kitcomponents.POSITION = model.POSITION;
            kitcomponents.COLOR = model.COLOR;
            kitcomponents.idKit = model.idKit;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "KitComponentes - Actualizar");
                return BadRequest();
            }

            return Ok();
        }
        // POST: api/KitComponentes/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<KitComponentes>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            KitComponentes kitcomponentes = new KitComponentes
            {
                NOMBRE = model.NOMBRE,
                CUSTOMPN = model.CUSTOMPN,
                POSITION = model.POSITION,
                COLOR = model.COLOR,
                TYPE = model.TYPE,
                idKit = model.idKit,
            };

            _context.KitComponentess.Add(kitcomponentes);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "KitComponentes - Crear");
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

            var kitcomponentes = await _context.KitComponentess.FindAsync(id);
            if (kitcomponentes == null)
            {
                return NotFound();
            }

            _context.KitComponentess.Remove(kitcomponentes);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "KitComponentes - Eliminar");
                return BadRequest();
            }

            return Ok(kitcomponentes);
        }

        private bool KitComponentesExists(int id)
        {
            return _context.KitComponentess.Any(e => e.idKitComponentes == id);
        }
    }
}
