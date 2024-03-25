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
    public class S2019101Controller : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S2019101Controller(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/S2019101/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S2019101ViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S2019101s
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S2019101ViewModel
            {
                idProtocolo = s.idProtocolo,
                //idEstacion = s.idEstacion,
                F_ScanBumper = s.F_ScanBumper,
                F_ScanColor = s.F_ScanColor,
                F_PunchWeldSMRLH = s.F_PunchWeldSMRLH,
                F_PunchWeldPLALH = s.F_PunchWeldPLALH,
                F_PunchWeldPLARH = s.F_PunchWeldPLARH,
                F_PunchWeldSMRRH = s.F_PunchWeldSMRRH,
                F_PunchGlueCamera = s.F_PunchGlueCamera,
                Fk_ScanBumper = s.Fk_ScanBumper,
                Fk_ScanColor = s.Fk_ScanColor,
                Fk_PunchWeldSMRLH = s.Fk_PunchWeldSMRLH,
                Fk_PunchWeldPLALH = s.Fk_PunchWeldPLALH,
                Fk_PunchWeldPLARH = s.Fk_PunchWeldPLARH,
                Fk_PunchWeldSMRRH = s.Fk_PunchWeldSMRRH,
                Fk_PunchGlueCamera = s.Fk_PunchGlueCamera,
                P_CameraGlueTime = s.P_CameraGlueTime,
                P_CameraGluePressure = s.P_CameraGluePressure,

            });


        }

        private bool S2019101Exists(int id)
        {
            return _context.S2019101s.Any(e => e.id == id);
        }
    }
}
