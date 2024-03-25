using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Productos;
using SCADA_A.Web.Models.Productos.Fascia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering")]
    [Route("api/[controller]")]
    [ApiController]
    public class FasciasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public FasciasController(DbContextSCADA_A context)
        {
            _context = context;
        }
        // GET: api/Fascias/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<FasciaViewModel>> Listar()
        {
            var fascia = await _context.Fascias
                .ToListAsync();

            return fascia.Select(i => new FasciaViewModel
            {
                idFascia = i.idFascia,
                ModeloM100Pos0 = i.ModeloM100Pos0,
                VersionM100Pos0 = i.VersionM100Pos0,
                FechaYHora = i.FechaYHora,
                NombreVersion = i.NombreVersion,
                Estatus = i.Estatus,

            });
        }

        // GET: api/Fascias/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Fascia>> Mostrar([FromRoute] int id)
        {
            var fascia = await _context.Fascias
                .SingleOrDefaultAsync(a => a.idFascia == id);
 
            if (fascia == null)
            {
                return NotFound();
            }

            return Ok(new FasciaViewModel
            {
                idFascia = fascia.idFascia,
                ModeloM100Pos0 = fascia.ModeloM100Pos0,
                VersionM100Pos0 = fascia.VersionM100Pos0,
                FechaYHora = fascia.FechaYHora,
                NombreVersion = fascia.NombreVersion,
                Estatus = fascia.Estatus,
            });
        }
        // GET: api/Facias/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var fascia = await _context.Fascias
                .Where(c => c.Estatus == true)
                .ToListAsync();

            return fascia.Select(i => new SelectViewModel
            {
                idFascia = i.idFascia,
                ModeloM100Pos0 = i.ModeloM100Pos0,
                VersionM100Pos0 = i.VersionM100Pos0,
                NombreVersion = i.NombreVersion,

            });
        }

        // PUT: api/Fascias/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idFascia <= 0)
            {
                return BadRequest();
            }

            var fascia = await _context.Fascias.FirstOrDefaultAsync(a => a.idFascia == model.idFascia);

            if (fascia == null)
            {
                return NotFound();
            }

            fascia.idFascia = model.idFascia;
            fascia.ModeloM100Pos0 = model.ModeloM100Pos0;
            fascia.VersionM100Pos0 = model.VersionM100Pos0;
            fascia.FechaYHora = DateTime.Now;
            fascia.NombreVersion = model.NombreVersion;


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Fascia - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Fascias/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Fascia>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Fascia fascia = new Fascia
            {
                ModeloM100Pos0 = model.ModeloM100Pos0,
                VersionM100Pos0 = model.VersionM100Pos0,
                FechaYHora = DateTime.Now,
                NombreVersion = model.NombreVersion,
                Estatus = true,
            };

            _context.Fascias.Add(fascia);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Fascia - Crear");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Fascias/Crears
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Fascia>> Crears([FromBody] List<CrearViewModel> model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (CrearViewModel item in model)
            {
                Fascia fascia = new Fascia
                {
                    ModeloM100Pos0 = item.ModeloM100Pos0,
                    VersionM100Pos0 = item.VersionM100Pos0,
                    FechaYHora = DateTime.Now,
                    NombreVersion = item.NombreVersion,
                    Estatus = true,
                };
                _context.Fascias.Add(fascia);
            };

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Fascia - Crears");
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Fascias/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var fascia = await _context.Fascias.FindAsync(id);
            if (fascia == null)
            {
                return NotFound();
            }

            _context.Fascias.Remove(fascia);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Fascia - Eliminar");
                return BadRequest();
            }

            return Ok(fascia);
        }

        // PUT: api/Fascias/Activar/1
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

            var fascia = await _context.Fascias.FirstOrDefaultAsync(s => s.idFascia == id);

            if (fascia == null)
            {
                return NotFound();
            }

            fascia.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Fascia - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Fascias/Desactivar/1
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

            var fascia = await _context.Fascias.FirstOrDefaultAsync(s => s.idFascia == id);

            if (fascia == null)
            {
                return NotFound();
            }

            fascia.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Fascia - Desactivar");
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/Fascias/BuscarenBOOM/1
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<ResultGOODSBOMbuscarfascia>> BuscarenBOOM([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute GOODSBOM_buscar_fascia @codigocolor=" + model.codigocolor + ", @valor="+ model.valor;
            
            var result = _context.GOODSBOM_buscar_fascia(sqlQuery);
            //return (result);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }
        private bool FasciaExists(int id)
        {
            return _context.Fascias.Any(e => e.idFascia == id);
        }
    }
}
