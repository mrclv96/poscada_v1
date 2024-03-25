using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Estaciones;
using SCADA_A.Entidades.OEE;
using SCADA_A.Web.Models.Estaciones.Estacion;
using SCADA_A.Web.Models.OEE.Scrap;


namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductCostVsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ProductCostVsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/ProductCostVs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductCostVViewModel>> Listar()
        {
            var productcostv = await _context.ProductCostVs
                .Take(100)
                .ToListAsync();

            return productcostv.Select(p => new ProductCostVViewModel
            {
                MaterialId = p.MaterialId,
                Plant = p.Plant,
                ValType = p.ValType,
                MaterialDescription = p.MaterialDescription,
                MTyp = p.MTyp,
                MatlGroup = p.MatlGroup,
                BUn = p.BUn,
                PGr = p.PGr,
                ABC = p.ABC,
                Typ = p.Typ,
                ValCl = p.ValCl,
                Prc = p.Prc,
                Created = p.Created,
                LastChg = p.LastChg,
                Price = p.Price,
                Crcy = p.Crcy,
                per = p.per,
                UnPrice = p.UnPrice,

            });
        }

        // GET: api/ProductCostVs/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<ProductCostV>> Mostrar([FromRoute] int id)
        {
            var productcostv = await _context.ProductCostVs
                .SingleOrDefaultAsync(p => p.MaterialId == id);


            if (productcostv == null)
            {
                return NotFound();
            }

            return Ok(new ProductCostVViewModel
            {
                MaterialId = productcostv.MaterialId,
                Plant = productcostv.Plant,
                ValType = productcostv.ValType,
                MaterialDescription = productcostv.MaterialDescription,
                MTyp = productcostv.MTyp,
                MatlGroup = productcostv.MatlGroup,
                BUn = productcostv.BUn,
                PGr = productcostv.PGr,
                ABC = productcostv.ABC,
                Typ = productcostv.Typ,
                ValCl = productcostv.ValCl,
                Prc = productcostv.Prc,
                Created = productcostv.Created,
                LastChg = productcostv.LastChg,
                Price = productcostv.Price,
                Crcy = productcostv.Crcy,
                per = productcostv.per,
                UnPrice = productcostv.UnPrice,
            });
        }

        private bool ProductCostVExists(int id)
        {
            return _context.ProductCostVs.Any(e => e.MaterialId == id);
        }
    }
}
