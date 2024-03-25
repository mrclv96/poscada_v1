using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.OEE;
using SCADA_A.Web.Models.OEE.App_Types;
using SCADA_A.Web.Models.OEE.Scrap;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class App_TypesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public App_TypesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/App_Types /Listar
        [Authorize(Roles = "Admin,Paint")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<App_TypesViewModel>> Listar()
        {
            var apptypes = await _context.App_Typess

                .ToListAsync();

            return apptypes.Select(t => new App_TypesViewModel
            {
                TypeID = t.TypeID,
                TypeCode = t.TypeCode,
                TypeLab = t.TypeLab,
                TypePartNb1 = t.TypePartNb1,
                TypePartNb2 = t.TypePartNb2,
                TypeAuthor = t.TypeAuthor,
                TypeStatus = t.TypeStatus,

            });
        }
        // GET: api/App_Types/Select
        [Authorize(Roles = "Admin,Paint")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var apptypes = await _context.App_Typess
                .Where(t => t.TypeAuthor == "Yes")
                .ToListAsync();

            return apptypes.Select(t => new SelectViewModel
            {
                TypeCode = t.TypeCode,
                TypeLab = t.TypeLab,
                TypePartNb1 = t.TypePartNb1,
                TypePartNb2 = t.TypePartNb2,
                TypeStatus = t.TypeStatus,

            });
        }

        // PUT: api/App_Types/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Paint")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] short id)
        {

            if (App_TypesExists(id) is false)
            {
                return BadRequest();
            }

            var apptypes = await _context.App_Typess.FirstOrDefaultAsync(a => a.TypeID == id);

            if (apptypes == null)
            {
                return NotFound();
            }

            apptypes.TypeStatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/App_Types/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Paint")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] short id)
        {

            if (App_TypesExists(id) is false)
            {
                return BadRequest();
            }

            var apptypes = await _context.App_Typess.FirstOrDefaultAsync(a => a.TypeID == id);

            if (apptypes == null)
            {
                return NotFound();
            }

            apptypes.TypeStatus = false;

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
        // PUT: api/App_Types/ScrapPorModelo/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<ScrapPorModelo>> ScrapPorModelo([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.scrapPorModelo @fechai='" + model.fechai + "', @fechaf='"+ model.fechaf +"', @status='"+ model.status +"' " ;
                //"exec scrapPorModelo @fechai=" + model.fechai + ", @fechaf=" + model.fechaf  + ", @status=" + model.status;

            var result = _context.Scrap_Por_Modelo(sqlQuery);
            //return (result);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/ScrapPorProductoCosto/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<ScrapPorProductoCosto>> ScrapPorProductoCosto([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.ScrapPorProductoCosto @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "', @status='" + model.status + "' ";
            //"exec scrapPorModelo @fechai=" + model.fechai + ", @fechaf=" + model.fechaf  + ", @status=" + model.status;

            var result = _context.Scrap_Por_Producto_Costos(sqlQuery);
            //return (result);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/TotalPiezasProducidas/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<TotalPiezasProducidas>> TotalPiezasProducidas([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.TotalPiezasProducidas @fechai='" + model.fechai + "', @fechaf='" + model.fechaf +"' ";

            var result = _context.Total_Piezas_Producidas(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/TotalPiezasTiempoCostporTipo/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<TotalPiezasTiempoCostporTipo>> TotalPiezasTiempoCostporTipo([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.TotalPiezasTiempoCostporTipo @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "', @status='" + model.status + "' ";

            var result = _context.Total_Piezas_Tiempo_Cost_por_Tipo(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/DistribucionScrap/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<DistribucionScrap>> DistribucionScrap([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.DistribucionScrap @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "' ";

            var result = _context.Distribucion_Scrap(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/DistribucionCostoScrap/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<DistribucionCostoScrap>> DistribucionCostoScrap([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.DistribucionCostoScrap @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "' ";

            var result = _context.Distribucion_Costo_Scrap(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/DistribucionCostoScrapPorTipo/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<DistribucionCostoScrapPorTipo>> DistribucionCostoScrapPorTipo([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.DistribucionCostoScrapPorTipo @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "', @status='" + model.status + "' ";

            var result = _context.Distribucion_Costo_Scrap_Por_Tipo(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/DistribucionCostoScrapPorTipos/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<DistribucionCostoScrapPorTipos>> DistribucionCostoScrapPorTipos([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.DistribucionCostoScrapPorTipos @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "' ";

            var result = _context.Distribucion_Costo_Scrap_Por_Tipos(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // PUT: api/App_Types/ScrapPorDefectoCosto/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<ScrapPorDefectoCosto>> ScrapPorDefectoCosto([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.ScrapPorDefectoCosto @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "' ";

            var result = _context.Scrap_Por_Defecto_Costo(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }
            
            return Ok(result);

        }

        // PUT: api/App_Types/TotalPiezasCostporModelo/1
        [Authorize(Roles = "Admin,Paint")]
        [HttpPost("[action]")]
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<ActionResult<TotalPiezasCostporModelo>> TotalPiezasCostporModelo([FromBody] ParametersViewModel model)
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            // Processing.  
            string sqlQuery = "execute Paintline_OEE.dbo.TotalPiezasCostporModelo @fechai='" + model.fechai + "', @fechaf='" + model.fechaf + "' ";

            var result = _context.Total_Piezas_Cost_por_Modelo(sqlQuery);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);

        }

        // GET: api/App_Types/ScrapMinMaxDate
        [Authorize(Roles = "Admin,Paint")]
        [HttpGet("[action]")]
        public async Task<ActionResult<MaxMinSQPTransaction>> ScrapMinMaxDate()
        {
            string sqlQuery = "execute Paintline_OEE.dbo.getMaxMintbTransaction";

            var result = _context.MaxMin_SQP_Transaction(sqlQuery);
            //return (result);

            if (result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }

        private bool App_TypesExists(short id)
        {
            return _context.App_Typess.Any(e => e.TypeID == id);
        }
    }
}
