using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Produccion;
using SCADA_A.Web.Models.Produccion;
using SCADA_A.Web.Models.Produccion.Protocolo;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProtocolosController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ProtocolosController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Protocolos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProtocoloViewModel>> Listar()
        {
            var protocolo = await _context.Protocolos
                .Include(p => p.orden)
                .Include(p => p.orden.producto)
                .Include(p => p.orden.producto.fascia)
                .Include(p => p.orden.color)
                .Include(p => p.estacion)
                .Include(p => p.estacion.linea)
                .OrderByDescending(p => p.DateAndTimeIn)
                .Take(200)
                .ToListAsync();

            return protocolo.Select(p => new ProtocoloViewModel
            {
                idProtocolo = p.idProtocolo,
                //idEstacion = p.idEstacion,
                Linea = p.estacion.linea.Nombre,
                Estacion = p.idEstacion + " " + p.estacion.Nombre,
                DateAndTimeIn = p.DateAndTimeIn,
                DateAndTimeFbk = p.DateAndTimeFbk,
                FlujoActual = p.FlujoActual,
                PKN = p.orden.PKN,
                JitSec = p.orden.JitSec,
                //Modelo = p.orden.producto.fascia.ModeloM100Pos0,
                //Version = p.orden.producto.fascia.VersionM100Pos0,
                Version = p.orden.producto.fascia.ModeloM100Pos0 + " " + p.orden.producto.fascia.VersionM100Pos0 + " " + p.orden.color.CodigoColor,
                Variante = p.orden.producto.Variante,
                //Color = p.orden.color.Nombre,
                RGBHex = p.orden.color.RGBHex,
                TiempoCiclo = p.TiempoCiclo,
                EstatusMaquina = p.EstatusMaquina,
                EstatusCalidad = p.EstatusCalidad,
                Comentario = p.Comentario
            });
            ;
        }

        // GET: api/Protocolos/Select/05
        [HttpGet("[action]/{id}")]
        public async Task<IEnumerable<ProtocoloViewModel>> Select([FromRoute] string id)
        {
            var protocolo = await _context.Protocolos
                .Include(p => p.orden)
                .Include(p => p.orden.producto)
                .Include(p => p.orden.producto.fascia)
                .Include(p => p.orden.color)
                .Include(p => p.estacion)
                .Include(p => p.estacion.linea)
                .Where(p => p.idOrden == Int64.Parse(id))
                .ToListAsync();

            return protocolo.Select(p => new ProtocoloViewModel
            {
                idProtocolo = p.idProtocolo,
                //idEstacion = p.idEstacion,
                Linea = p.estacion.linea.Nombre,
                Estacion = p.idEstacion + " " + p.estacion.Nombre,
                DateAndTimeIn = p.DateAndTimeIn,
                DateAndTimeFbk = p.DateAndTimeFbk,
                FlujoActual = p.FlujoActual,
                PKN = p.orden.PKN,
                JitSec = p.orden.JitSec,
                //Modelo = p.orden.producto.fascia.ModeloM100Pos0,
                //Version = p.orden.producto.fascia.VersionM100Pos0,
                Version = p.orden.producto.fascia.ModeloM100Pos0 + " " + p.orden.producto.fascia.VersionM100Pos0 + " " + p.orden.color.CodigoColor,
                Variante = p.orden.producto.Variante,
                //Color = p.orden.color.Nombre,
                RGBHex = p.orden.color.RGBHex,
                TiempoCiclo = p.TiempoCiclo,
                EstatusMaquina = p.EstatusMaquina,
                EstatusCalidad = p.EstatusCalidad,
                Comentario = p.Comentario
            });
            ;
        }

        // GET: api/Protocolos/ListarFiltro/texto
        [HttpGet("[action]/{texto}")]
        public async Task<IEnumerable<ProtocoloViewModel>> ListarFiltro([FromRoute] string texto)
        {
            var protocolo = await _context.Protocolos
                .Include(p => p.orden)
                .Include(p => p.orden.producto)
                .Include(p => p.orden.producto.fascia)
                .Include(p => p.orden.color)
                .Include(p => p.estacion)
                .Include(p => p.estacion.linea)
                .Where(p => p.orden.PKN.ToString().Contains(texto) || p.orden.JitSec.ToString().Contains(texto)
                || p.Comentario.Contains(texto) || p.idEstacion.Contains(texto) || p.estacion.Nombre.Contains(texto))
                .OrderByDescending(p => p.DateAndTimeIn)
                .Take(200)
                .ToListAsync();

            return protocolo.Select(p => new ProtocoloViewModel
            {
                idProtocolo = p.idProtocolo,
                //idEstacion = p.idEstacion,
                Linea = p.estacion.linea.Nombre,
                Estacion = p.idEstacion + " " + p.estacion.Nombre,
                DateAndTimeIn = p.DateAndTimeIn,
                DateAndTimeFbk = p.DateAndTimeFbk,
                FlujoActual = p.FlujoActual,
                PKN = p.orden.PKN,
                JitSec = p.orden.JitSec,
                //Modelo = p.orden.producto.fascia.ModeloM100Pos0,
                //Version = p.orden.producto.fascia.VersionM100Pos0,
                Version = p.orden.producto.fascia.ModeloM100Pos0 + " " + p.orden.producto.fascia.VersionM100Pos0 + " " + p.orden.color.CodigoColor,
                Variante = p.orden.producto.Variante,
                //Color = p.orden.color.Nombre,
                RGBHex = p.orden.color.RGBHex,
                TiempoCiclo = p.TiempoCiclo,
                EstatusMaquina = p.EstatusMaquina,
                EstatusCalidad = p.EstatusCalidad,
                Comentario = p.Comentario
            });
            ;
        }
        // POST: api/Ordenes/ListarFiltroFecha/
        [HttpPost("[action]")]
        public async Task<IEnumerable<ProtocoloViewModel>> ListarFiltroFecha([FromBody] SearchDateViewModel model)
        {
            var protocolo = await _context.Protocolos
                .Include(p => p.orden)
                .Include(p => p.orden.producto)
                .Include(p => p.orden.producto.fascia)
                .Include(p => p.orden.color)
                .Include(p => p.estacion)
                .Include(p => p.estacion.linea)
                .Where(p => p.DateAndTimeIn <= model.EndTime && p.DateAndTimeIn >= model.StartTime)
                .OrderByDescending(p => p.DateAndTimeIn)
                .Take(200)
                .ToListAsync();

            return protocolo.Select(p => new ProtocoloViewModel
            {
                idProtocolo = p.idProtocolo,
                //idEstacion = p.idEstacion,
                Linea = p.estacion.linea.Nombre,
                Estacion = p.idEstacion + " " + p.estacion.Nombre,
                DateAndTimeIn = p.DateAndTimeIn,
                DateAndTimeFbk = p.DateAndTimeFbk,
                FlujoActual = p.FlujoActual,
                PKN = p.orden.PKN,
                JitSec = p.orden.JitSec,
                //Modelo = p.orden.producto.fascia.ModeloM100Pos0,
                //Version = p.orden.producto.fascia.VersionM100Pos0,
                Version = p.orden.producto.fascia.ModeloM100Pos0 + " " + p.orden.producto.fascia.VersionM100Pos0 + " " + p.orden.color.CodigoColor,
                Variante = p.orden.producto.Variante,
                //Color = p.orden.color.Nombre,
                RGBHex = p.orden.color.RGBHex,
                TiempoCiclo = p.TiempoCiclo,
                EstatusMaquina = p.EstatusMaquina,
                EstatusCalidad = p.EstatusCalidad,
                Comentario = p.Comentario
            });
            ;
        }
        // POST: api/Ordenes/ListarFiltroPKNJitSec/
        [HttpPost("[action]")]
        public async Task<IEnumerable<ProtocoloViewModel>> ListarFiltroPKNJitSec([FromBody] PKNJitSecViewModel model)
        {
            var protocolo = await _context.Protocolos
                .Include(p => p.orden)
                .Include(p => p.orden.producto)
                .Include(p => p.orden.producto.fascia)
                .Include(p => p.orden.color)
                .Include(p => p.estacion)
                .Include(p => p.estacion.linea)
                .Where(p => p.orden.PKN == Int64.Parse(model.PKN) && p.orden.JitSec == model.JitSec)
                .OrderByDescending(p => p.DateAndTimeIn)
                .Take(200)
                .ToListAsync();

            return protocolo.Select(p => new ProtocoloViewModel
            {
                idProtocolo = p.idProtocolo,
                //idEstacion = p.idEstacion,
                Linea = p.estacion.linea.Nombre,
                Estacion = p.idEstacion + " " + p.estacion.Nombre,
                DateAndTimeIn = p.DateAndTimeIn,
                DateAndTimeFbk = p.DateAndTimeFbk,
                FlujoActual = p.FlujoActual,
                PKN = p.orden.PKN,
                JitSec = p.orden.JitSec,
                //Modelo = p.orden.producto.fascia.ModeloM100Pos0,
                //Version = p.orden.producto.fascia.VersionM100Pos0,
                Version = p.orden.producto.fascia.ModeloM100Pos0 + " " + p.orden.producto.fascia.VersionM100Pos0 + " " + p.orden.color.CodigoColor,
                Variante = p.orden.producto.Variante,
                //Color = p.orden.color.Nombre,
                RGBHex = p.orden.color.RGBHex,
                TiempoCiclo = p.TiempoCiclo,
                EstatusMaquina = p.EstatusMaquina,
                EstatusCalidad = p.EstatusCalidad,
                Comentario = p.Comentario
            });
            ;
        }

        private bool ProtocoloExists(int id)
        {
            return _context.Protocolos.Any(e => e.idProtocolo == id);
        }
    }
}
