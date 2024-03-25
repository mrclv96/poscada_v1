using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.OEE;
using SCADA_A.Web.Models.OEE;
using SCADA_A.Web.Models.OEE.Scrap;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SAPScrapVsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public SAPScrapVsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/SAPScrapVs/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<SAPScrapVViewModel>> Listar()
        {
            var sapscrapv = await _context.SAPScrapVs
                .Take(100)
                .ToListAsync();

            return sapscrapv.Select(s => new SAPScrapVViewModel
            {
               Pstng_DateTime = s.Pstng_DateTime,
               Material = s.Material,
               Material_Description = s.Material_Description,
               MvT = s.MvT,
               Item = s.Item,
               Mat_Doc = s.Mat_Doc,
               SLoc = s.SLoc,
               Reas = s.Reas,
               Reference = s.Reference,
               Document_Header_Text = s.Document_Header_Text,
               Plnt = s.Plnt,
               User_name = s.User_name,
               Quantity_in_UnE = s.Quantity_in_UnE,
               EUn = s.EUn,
               Crcy = s.Crcy,
               Amount_in_LC = s.Amount_in_LC,

            });
        }

        // POST: api/SAPScrapVs/ListarFiltroFecha/
        [HttpPost("[action]")]
        public async Task<IEnumerable<SAPScrapVViewModel>> ListarFiltroFecha([FromBody] SearchDateViewModel model)
        {
            var sapscrapv = await _context.SAPScrapVs
                .Where(s => s.Pstng_DateTime <= model.EndTime && s.Pstng_DateTime >= model.StartTime)
                .OrderByDescending(s => s.Pstng_DateTime)
                .Take(200)
                .ToListAsync();

            return sapscrapv.Select(s => new SAPScrapVViewModel
            {
                Pstng_DateTime = s.Pstng_DateTime,
                Material = s.Material,
                Material_Description = s.Material_Description,
                MvT = s.MvT,
                Item = s.Item,
                Mat_Doc = s.Mat_Doc,
                SLoc = s.SLoc,
                Reas = s.Reas,
                Reference = s.Reference,
                Document_Header_Text = s.Document_Header_Text,
                Plnt = s.Plnt,
                User_name = s.User_name,
                Quantity_in_UnE = s.Quantity_in_UnE,
                EUn = s.EUn,
                Crcy = s.Crcy,
                Amount_in_LC = s.Amount_in_LC,
            });
            ;
        }

        private bool SAPScrapVExists(DateTime id)
        {
            return _context.SAPScrapVs.Any(e => e.Pstng_DateTime == id);
        }
    }
}
