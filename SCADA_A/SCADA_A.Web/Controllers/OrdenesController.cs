using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Web.Models.Produccion;
using SCADA_A.Web.Models.Produccion.Orden;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public OrdenesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Ordenes/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<OrdenViewModel>> Listar()
        {
            var orden = await _context.Ordenes
                .Include(o => o.producto)
                .Include(o => o.producto.fascia)
                .Include(o => o.producto.secuencia)
                .Include(o => o.producto.secuencia.linea)
                .Include(o => o.color)
                .OrderByDescending(o => o.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return orden.Select(o => new OrdenViewModel
            {
                idOrden = o.idOrden.ToString(),
                PKN = o.PKN,
                JitSec = o.JitSec,
                Modelo = o.producto.fascia.ModeloM100Pos0,
                Version = o.producto.fascia.VersionM100Pos0,
                CodigoColor = o.CodigoColor,
                Color = o.color.Nombre,
                RGBHex = o.color.RGBHex,
                NombreVersion = o.producto.fascia.NombreVersion,
                Variante = o.Variante,
                Linea = o.producto.secuencia.linea.Nombre,
                Secuencia = o.producto.secuencia.Flujo,
                FechaYHoraCreacion = o.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.Comentario,
            });
            ;
        }
        // GET: api/Ordenes/ListarFiltro/texto
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<OrdenViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var orden = await _context.Ordenes
                .Include(o => o.producto)
                .Include(o => o.producto.fascia)
                .Include(o => o.producto.secuencia)
                .Include(o => o.producto.secuencia.linea)
                .Include(o => o.color)
                .Where(o => o.PKN.ToString().Contains(texto) || o.JitSec.ToString().Contains(texto) || o.Comentario.ToString().Contains(texto))
                .OrderByDescending(o => o.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return orden.Select(o => new OrdenViewModel
            {
                idOrden = o.idOrden.ToString(),
                PKN = o.PKN,
                JitSec = o.JitSec,
                Modelo = o.producto.fascia.ModeloM100Pos0,
                Version = o.producto.fascia.VersionM100Pos0,
                CodigoColor = o.CodigoColor,
                Color = o.color.Nombre,
                RGBHex = o.color.RGBHex,
                NombreVersion = o.producto.fascia.NombreVersion,
                Variante = o.producto.Variante,
                Linea = o.producto.secuencia.linea.Nombre,
                Secuencia = o.producto.secuencia.Flujo,
                FechaYHoraCreacion = o.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.Comentario,
            });
            ;
        }
        // POST: api/Ordenes/ListarFiltroFecha/
        [HttpPost("[action]")]
        public async Task<IEnumerable<OrdenViewModel>> ListarFiltroFecha([FromBody] SearchDateViewModel model)
        {
            var orden = await _context.Ordenes
                .Include(o => o.producto)
                .Include(o => o.producto.fascia)
                .Include(o => o.producto.secuencia)
                .Include(o => o.producto.secuencia.linea)
                .Include(o => o.color)
                .Where(o => o.FechaYHoraCreacion <= model.EndTime && o.FechaYHoraCreacion >= model.StartTime)
                .OrderByDescending(o => o.FechaYHoraCreacion)
                .Take(200)
                .ToListAsync();

            return orden.Select(o => new OrdenViewModel
            {
                idOrden = o.idOrden.ToString(),
                PKN = o.PKN,
                JitSec = o.JitSec,
                Modelo = o.producto.fascia.ModeloM100Pos0,
                Version = o.producto.fascia.VersionM100Pos0,
                CodigoColor = o.CodigoColor,
                Color = o.color.Nombre,
                RGBHex = o.color.RGBHex,
                NombreVersion = o.producto.fascia.NombreVersion,
                Variante = o.producto.Variante,
                Linea = o.producto.secuencia.linea.Nombre,
                Secuencia = o.producto.secuencia.Flujo,
                FechaYHoraCreacion = o.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.Comentario,
            });
            ;
        }
        // POST: api/Ordenes/ListarFiltroPKNJitSec/
        [HttpPost("[action]")]
        public async Task<IEnumerable<OrdenViewModel>> ListarFiltroPKNJitSec([FromBody] PKNJitSecViewModel model)
        {
            var orden = await _context.Ordenes
                .Include(o => o.producto)
                .Include(o => o.producto.fascia)
                .Include(o => o.producto.secuencia)
                .Include(o => o.producto.secuencia.linea)
                .Include(o => o.color)
                .Where(o => o.PKN == Int64.Parse(model.PKN) && o.JitSec == model.JitSec)
                .OrderByDescending(o => o.FechaYHoraCreacion)
                //.Take(100)
                .ToListAsync();

            return orden.Select(o => new OrdenViewModel
            {
                idOrden = o.idOrden.ToString(),
                PKN = o.PKN,
                JitSec = o.JitSec,
                Modelo = o.producto.fascia.ModeloM100Pos0,
                Version = o.producto.fascia.VersionM100Pos0,
                CodigoColor = o.CodigoColor,
                Color = o.color.Nombre,
                RGBHex = o.color.RGBHex,
                NombreVersion = o.producto.fascia.NombreVersion,
                Variante = o.producto.Variante,
                Linea = o.producto.secuencia.linea.Nombre,
                Secuencia = o.producto.secuencia.Flujo,
                FechaYHoraCreacion = o.FechaYHoraCreacion,
                Estatus = o.Estatus,
                Comentario = o.Comentario,
            });
            ;
        }

        private bool OrdenExists(long id)
        {
            return _context.Ordenes.Any(e => e.idOrden == id);
        }
    }
}
