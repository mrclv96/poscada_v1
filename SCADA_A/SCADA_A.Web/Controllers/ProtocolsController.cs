using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.OEE;
using SCADA_A.Web.Models.OEE.Protocol;


namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocolsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ProtocolsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Protocols/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProtocolViewModel>> Listar()
        {
            var protocol = await _context.Protocols
                .Take(100)
                .ToListAsync();

            return protocol.Select(p => new ProtocolViewModel
            {
                idProtocol = p.idProtocol,
                Nombre = p.Nombre,
                Valor = p.Valor,
                Comentario = p.Comentario,
                tipo = p.tipo,
                Estatus = p.Estatus,

            });
        }

        // GET: api/Protocols/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProtocolViewModel>> Select()
        {
            var protocol = await _context.Protocols
                .Where(p => p.Estatus == true)
                .ToListAsync();

            return protocol.Select(p => new ProtocolViewModel
            {
                idProtocol = p.idProtocol,
                Nombre = p.Nombre,
                Valor = p.Valor,
                Comentario = p.Comentario,
                tipo = p.tipo,
                Estatus = p.Estatus,

            });
        }

        // GET: api/Protocols/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Protocol>> Mostrar([FromRoute] Int16 id)
        {
            var protocol = await _context.Protocols
                .SingleOrDefaultAsync(a => a.idProtocol == id);


            if (protocol == null)
            {
                return NotFound();
            }

            return Ok(new ProtocolViewModel
            {
                idProtocol = protocol.idProtocol,
                Nombre = protocol.Nombre,
                Valor = protocol.Valor,
                Comentario = protocol.Comentario,
                tipo = protocol.tipo,
                Estatus = protocol.Estatus,
            });
        }

        // PUT: api/Protocols/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ProtocolViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (ProtocolExists(model.idProtocol) is false)
            {
                return BadRequest();
            }

            var protocol = await _context.Protocols.FirstOrDefaultAsync(a => a.idProtocol == model.idProtocol);

            if (protocol == null)
            {
                return NotFound();
            }

            protocol.Nombre = model.Nombre;
            protocol.Valor = model.Valor;
            protocol.Comentario = model.Comentario;
            protocol.tipo = model.tipo;
            protocol.Estatus = model.Estatus;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Protocol - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Protocols/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<Protocol>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Protocol protocol = new Protocol
            {
                Nombre = model.Nombre,
                Valor = model.Valor,
                Comentario = model.Comentario,
                tipo = model.tipo,
                Estatus = true,
            };

            _context.Protocols.Add(protocol);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Protocol - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Protocols/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] Int16 id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var protocol = await _context.Protocols.FindAsync(id);
            if (protocol == null)
            {
                return NotFound();
            }

            _context.Protocols.Remove(protocol);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Protocolo - Eliminar");
                return BadRequest();
            }

            return Ok(protocol);
        }
        // PUT: api/Estaciones/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] Int16 id)
        {

            if (ProtocolExists(id) is false)
            {
                return BadRequest();
            }

            var protocol = await _context.Protocols.FirstOrDefaultAsync(a => a.idProtocol == id);

            if (protocol == null)
            {
                return NotFound();
            }

            protocol.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Protocol - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Estaciones/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] Int16 id)
        {

            if (ProtocolExists(id) is false)
            {
                return BadRequest();
            }

            var protocol = await _context.Protocols.FirstOrDefaultAsync(a => a.idProtocol == id);
            
            if (protocol == null)
            {
                return NotFound();
            }

            protocol.Estatus = false;

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

        private bool ProtocolExists(short id)
        {
            return _context.Protocols.Any(e => e.idProtocol == id);
        }
    }
}
