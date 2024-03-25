using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Trace;
using SCADA_A.Web.Models.Trace.LogTrace;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogTracesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public LogTracesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/LogTraces/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<LogTraceViewModel>> Listar()
        {
            var log = await _context.LogTraces
                .Include(l => l.usuario)
                .OrderByDescending(l => l.DateAndTime)
                .Take(100)
                .ToListAsync();

            return log.Select(l => new LogTraceViewModel
            {
                DateAndTime = l.DateAndTime,
                Usuario = l.usuario.Nombre,
                Table = l.Table,
                Description = l.Description,
            });
            ;
        }
        // GET: api/LogTraces/ListarFiltro/texto
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<LogTraceViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var log = await _context.LogTraces
                .Include(l => l.usuario)
                .Where(l => l.Description.Contains(texto) || l.Table.Contains(texto) )
                .OrderByDescending(l => l.DateAndTime)                          
                .Take(100)
                .ToListAsync();

            return log.Select(l => new LogTraceViewModel
            {
                DateAndTime = l.DateAndTime,
                Usuario = l.usuario.Nombre,
                Table = l.Table,
                Description = l.Description,
            });
            ;
        }
        // GET: api/LogTraces/ListarFiltroFecha/
        [HttpPost("[action]")]
        public async Task<IEnumerable<LogTraceViewModel>> ListarFiltroFecha([FromBody] SearchDateViewModel model)
        {
            var log = await _context.LogTraces
                .Include(l => l.usuario)
                .Where(l => l.DateAndTime <= model.EndTime && l.DateAndTime >= model.StartTime)
                .OrderByDescending(l => l.DateAndTime)
                //.Take(100)
                .ToListAsync();

            return log.Select(l => new LogTraceViewModel
            {
                DateAndTime = l.DateAndTime,
                Usuario = l.usuario.Nombre,
                Table = l.Table,
                Description = l.Description,
            });
            ;
        }
        // POST: api/LogTraces/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<LogTrace>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }


            LogTrace log = new LogTrace
            {
                DateAndTime = DateTime.Now,
                idUsuario = model.idUsuario,
                Table = model.Table,
                Description = model.Description

            };
            _context.LogTraces.Add(log);


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "LogTrace - Crear");
                return BadRequest();
            }

            return Ok();
        }

        private bool LogTraceExists(DateTime id)
        {
            return _context.LogTraces.Any(e => e.DateAndTime == id);
        }
    }
}
