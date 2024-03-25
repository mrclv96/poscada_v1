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
    public class S2019103Controller : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S2019103Controller(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/S2019103/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S2019103ViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S2019103s
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S2019103ViewModel
            {
                idProtocolo = s.idProtocolo,
                F_ScanBumper = s.F_ScanBumper,
                F_PunchWeldPLALH = s.F_PunchWeldPLALH,
                F_PunchWeldPDCLHO = s.F_PunchWeldPDCLHO,
                F_PunchWeldPDCLHI = s.F_PunchWeldPDCLHI,
                F_PunchWeldPDCRHI = s.F_PunchWeldPDCRHI,
                F_PunchWeldPDCRHO = s.F_PunchWeldPDCRHO,
                F_PunchWeldPLARH = s.F_PunchWeldPLARH,
                Fk_ScanBumper = s.Fk_ScanBumper,
                Fk_PunchWeldPLALH = s.Fk_PunchWeldPLALH,
                Fk_PunchWeldPDCLHO = s.Fk_PunchWeldPDCLHO,
                Fk_PunchWeldPDCLHI = s.Fk_PunchWeldPDCLHI,
                Fk_PunchWeldPDCRHI = s.Fk_PunchWeldPDCRHI,
                Fk_PunchWeldPDCRHO = s.Fk_PunchWeldPDCRHO,
                Fk_PunchWeldPLARH = s.Fk_PunchWeldPLARH,

            });


        }

        private bool S2019103Exists(int id)
        {
            return _context.S2019103s.Any(e => e.id == id);
        }
    }
}
