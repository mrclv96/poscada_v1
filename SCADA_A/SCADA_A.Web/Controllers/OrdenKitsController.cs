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
using SCADA_A.Web.Models.OnePieceFlow.OrdenKit;
using SCADA_A.Web.Models.Produccion;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenKitsController : Controller
    {
        private readonly DbContextSCADA_A _context;

        public OrdenKitsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/OrdenKits/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrdenKitViewModel>> Listar()
        {
            var ordenkit = await _context.OrdenKits
                .Include(o => o.orden.producto)
                .Include(o => o.orden.producto.fascia)
                .Include(o => o.orden.color)
                .Include(o => o.kit)
                .OrderByDescending(o => o.orden.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return ordenkit.Select(o => new OrdenKitViewModel
            {
                idOrdenKit = o.idOrdenKit.ToString(),
                idOrden = o.orden.idOrden.ToString(),
                idKit = o.idKit,
                PKN = o.orden.PKN,
                JitSec = o.orden.JitSec,
                Modelo = o.orden.producto.fascia.ModeloM100Pos0,
                Version = o.orden.producto.fascia.VersionM100Pos0,
                CodigoColor = o.orden.CodigoColor,
                Color = o.orden.color.Nombre,
                RGBHex = o.orden.color.RGBHex,
                NombreVersion = o.orden.producto.fascia.NombreVersion,
                Variante = o.orden.Variante,
                FechaYHoraCreacion = o.orden.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.orden.Comentario,
            });
            ;
        }

        // GET: api/OrdenKits/Mostrar
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrdenKitViewModel>> Mostrar()
        {
            var ordenkit = await _context.OrdenKits
                .Include(o => o.orden.producto)
                .Include(o => o.orden.producto.fascia)
                .Include(o => o.orden.color)
                .Include(o => o.kit)
                .Where(o => o.Estatus == 2)  
                .OrderBy(o => o.orden.JitSec)
                //.ThenByDescending(o => o.orden.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return ordenkit.Select(o => new OrdenKitViewModel
            {
                idOrdenKit = o.idOrdenKit.ToString(),
                idOrden = o.orden.idOrden.ToString(),
                idKit = o.idKit,
                PKN = o.orden.PKN,
                JitSec = o.orden.JitSec,
                Modelo = o.orden.producto.fascia.ModeloM100Pos0,
                Version = o.orden.producto.fascia.VersionM100Pos0,
                CodigoColor = o.orden.CodigoColor,
                Color = o.orden.color.Nombre,
                RGBHex = o.orden.color.RGBHex,
                NombreVersion = o.orden.producto.fascia.NombreVersion,
                Variante = o.orden.Variante,
                FechaYHoraCreacion = o.orden.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.orden.Comentario,
            });
            ;
        }

        // GET: api/OrdenKits/ListarFiltro/texto
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<OrdenKitViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var ordenkit = await _context.OrdenKits
                .Include(o => o.orden.producto)
                .Include(o => o.orden.producto.fascia)
                .Include(o => o.orden.color)
                .Include(o => o.kit)
                .Where(o => o.orden.Comentario.Contains(texto))
                .OrderByDescending(o => o.orden.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return ordenkit.Select(o => new OrdenKitViewModel
            {
                idOrdenKit = o.idOrdenKit.ToString(),
                idOrden = o.orden.idOrden.ToString(),
                idKit = o.idKit,
                PKN = o.orden.PKN,
                JitSec = o.orden.JitSec,
                Modelo = o.orden.producto.fascia.ModeloM100Pos0,
                Version = o.orden.producto.fascia.VersionM100Pos0,
                CodigoColor = o.orden.CodigoColor,
                Color = o.orden.color.Nombre,
                RGBHex = o.orden.color.RGBHex,
                NombreVersion = o.orden.producto.fascia.NombreVersion,
                Variante = o.orden.Variante,
                FechaYHoraCreacion = o.orden.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.orden.Comentario,
            });
            ;
        }

        // POST: api/OrdenKits/ListarFiltroFecha/
        [HttpPost("[action]")]
        public async Task<IEnumerable<OrdenKitViewModel>> ListarFiltroFecha([FromBody] SearchDateViewModel model)
        {
            var ordenkit = await _context.OrdenKits
                .Include(o => o.orden.producto)
                .Include(o => o.orden.producto.fascia)
                .Include(o => o.orden.color)
                .Include(o => o.kit)
                .Where(o => o.orden.FechaYHoraCreacion <= model.EndTime && o.orden.FechaYHoraCreacion >= model.StartTime)
                .OrderByDescending(o => o.orden.JitSec)
                .ThenByDescending(o => o.orden.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return ordenkit.Select(o => new OrdenKitViewModel
            {
                idOrdenKit = o.idOrdenKit.ToString(),
                idOrden = o.orden.idOrden.ToString(),
                idKit = o.idKit,
                PKN = o.orden.PKN,
                JitSec = o.orden.JitSec,
                Modelo = o.orden.producto.fascia.ModeloM100Pos0,
                Version = o.orden.producto.fascia.VersionM100Pos0,
                CodigoColor = o.orden.CodigoColor,
                Color = o.orden.color.Nombre,
                RGBHex = o.orden.color.RGBHex,
                NombreVersion = o.orden.producto.fascia.NombreVersion,
                Variante = o.orden.Variante,
                FechaYHoraCreacion = o.orden.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.orden.Comentario,
            });
            ;
            
        }
        // POST: api/OrdenKits/ListarFiltroPKNJitSec/
        [HttpPost("[action]")]
        public async Task<IEnumerable<OrdenKitViewModel>> ListarFiltroPKNJitSec([FromBody] PKNJitSecViewModel model)
        {
            var ordenkit = await _context.OrdenKits
                .Include(o => o.orden.producto)
                .Include(o => o.orden.producto.fascia)
                .Include(o => o.orden.color)
                .Include(o => o.kit)
                .Where(o => o.orden.PKN == Int64.Parse(model.PKN) && o.orden.JitSec == model.JitSec)
                .OrderByDescending(o => o.orden.JitSec)
                .ThenByDescending(o => o.orden.FechaYHoraCreacion)
                //.Take(100)
                .ToListAsync();

            return ordenkit.Select(o => new OrdenKitViewModel
            {
                idOrdenKit = o.idOrdenKit.ToString(),
                idOrden = o.orden.idOrden.ToString(),
                idKit = o.idKit,
                PKN = o.orden.PKN,
                JitSec = o.orden.JitSec,
                Modelo = o.orden.producto.fascia.ModeloM100Pos0,
                Version = o.orden.producto.fascia.VersionM100Pos0,
                CodigoColor = o.orden.CodigoColor,
                Color = o.orden.color.Nombre,
                RGBHex = o.orden.color.RGBHex,
                NombreVersion = o.orden.producto.fascia.NombreVersion,
                Variante = o.orden.Variante,
                FechaYHoraCreacion = o.orden.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.orden.Comentario,
            });
            ;
        }

        // PUT: api/OrdenKits/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering,Supervisor")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idOrdenKit < 0)
            {
                return BadRequest();
            }

            var ordenkit = await _context.OrdenKits.FirstOrDefaultAsync(a => a.idOrdenKit == model.idOrdenKit);

            if (ordenkit == null)
            {
                return NotFound();
            }

            ordenkit.Estatus = model.Estatus;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "OrdenKit - Actualizar");
                return BadRequest();
            }

            return Ok();
        }
        // POST: api/OrdenKits/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<ActionResult<OrdenKit>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            OrdenKit ordenkit = new OrdenKit
            {
                idOrden = model.idOrden,
                idKit = model.idKit,
                Estatus = 2,
            };

            _context.OrdenKits.Add(ordenkit);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "OrdenKit - Crear");
                return BadRequest();
            }

            return Ok();
        }

        private bool OrdenKitExists(long id)
        {
            return _context.OrdenKits.Any(e => e.idOrdenKit == id);
        }
    }
}
