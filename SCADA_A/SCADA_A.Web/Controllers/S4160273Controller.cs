using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.TPL;
using SCADA_A.Web.Models.TPL;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class S4160273Controller : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S4160273Controller(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/S4160273/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S4160273ViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S4160273s
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S4160273ViewModel
            {
                idProtocolo = s.idProtocolo,
                F_Etest = s.F_Etest,
                F_EtestAllVersion = s.F_EtestAllVersion,
                F_Clipping = s.F_Clipping,
                Fk_Etest = s.Fk_Etest,
                Fk_EtestAllVersion = s.Fk_EtestAllVersion,
                Fk_Clipping = s.Fk_Clipping,
                LoadScrapped = s.LoadScrapped,
                Sta1Scrapped = s.Sta1Scrapped,
                Sta2Scrapped = s.Sta2Scrapped,
                Sta3Scrapped = s.Sta3Scrapped,
                Sta4Scrapped = s.Sta4Scrapped,
                Sta1ACycleTime = s.Sta1ACycleTime,
                Sta1BCycleTime = s.Sta1BCycleTime,
                Sta2ACycleTime = s.Sta2ACycleTime,
                Sta2BCycleTime = s.Sta2BCycleTime,
                Sta3ACycleTime = s.Sta3ACycleTime,
                Sta3BCycleTime = s.Sta3BCycleTime,
                Sta4ACycleTime = s.Sta4ACycleTime,
                Sta4BCycleTime = s.Sta4BCycleTime,
                EtestVAPLA1 = s.EtestVAPLA1,
                EtestVAPLA2 = s.EtestVAPLA2,
                EtestVAPDC1 = s.EtestVAPDC1,
                EtestVAPDC2 = s.EtestVAPDC2,
                EtestVAPDC3 = s.EtestVAPDC3,
                EtestVAPDC4 = s.EtestVAPDC4,
                EtestVACAM = s.EtestVACAM,
                IdEtest = s.IdEtest,
            });
        }

        private bool S4160273Exists(int id)
        {
            return _context.S4160273s.Any(e => e.id == id);
        }
    }
}
