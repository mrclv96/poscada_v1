using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Trace;
using SCADA_A.Web.Models.Trace.ErrTrace;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ErrTracesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ErrTracesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/ErrTraces/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ErrTraceViewModel>> Listar()
        {
            var err = await _context.ErrTraces
                .OrderByDescending(l => l.DateAndTime)
                .Take(100)
                .ToListAsync();

            return err.Select(l => new ErrTraceViewModel
            {
                DateAndTime = l.DateAndTime,
                ProcedurName = l.ProcedurName,
                ErrNumber = l.ErrNumber,
                ErrSource = l.ErrSource,
                ErrDescription = l.ErrDescription,
            });
            ;
        }
        // GET: api/ErrTraces/ListarFiltro/texto
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<ErrTraceViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var err = await _context.ErrTraces
                .Where(l => l.ProcedurName.Contains(texto) || l.ErrSource.Contains(texto)
                        || l.ErrDescription.Contains(texto))
                .OrderByDescending(l => l.DateAndTime)
                .Take(100)
                .ToListAsync();

            return err.Select(l => new ErrTraceViewModel
            {
                DateAndTime = l.DateAndTime,
                ProcedurName = l.ProcedurName,
                ErrNumber = l.ErrNumber,
                ErrSource = l.ErrSource,
                ErrDescription = l.ErrDescription,
            });
            ;
        }
        // GET: api/ErrTraces/ListarFiltroFecha/
        [HttpPost("[action]")]
        public async Task<IEnumerable<ErrTraceViewModel>> ListarFiltroFecha([FromBody] SearchDateViewModel model)
        {
            var err = await _context.ErrTraces
                .Where(l => l.DateAndTime <= model.EndTime && l.DateAndTime >= model.StartTime)
                .OrderByDescending(l => l.DateAndTime)
                //.Take(100)
                .ToListAsync();

            return err.Select(l => new ErrTraceViewModel
            {
                DateAndTime = l.DateAndTime,
                ProcedurName = l.ProcedurName,
                ErrNumber = l.ErrNumber,
                ErrSource = l.ErrSource,
                ErrDescription = l.ErrDescription,
            });
            ;
        }
        // POST: api/ErrTraces/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<ErrTrace>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            ErrTrace err = new ErrTrace
            {
                DateAndTime = DateTime.Now,
                ProcedurName = model.ProcedurName,
                ErrDescription=model.ErrDescription,
                ErrNumber=model.ErrNumber,
                ErrSource=model.ErrSource,
            };
            _context.ErrTraces.Add(err);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "ErrTrace - Crear");
                return BadRequest();
            }

            return Ok();
        }

        private bool ErrTraceExists(DateTime id)
        {
            return _context.ErrTraces.Any(e => e.DateAndTime == id);
        }
    }
}
