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
    public class PunchDatasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public PunchDatasController(DbContextSCADA_A context)
        {
            _context = context;
        }
        // POST: api/PunchDatas/Select/
        [HttpPost("[action]")]
        public async Task<IEnumerable<PunchDataViewModel>> Select([FromBody] EstacionProtocoloViewModel model)
        {

            var temp = await _context.PunchDatas
                .Where(s => s.idProtocolo == model.idProtocolo && s.idEstacion == model.idEstacion)
                .ToListAsync();

            return temp.Select(s => new PunchDataViewModel
            {
                idProtocolo = s.idProtocolo,
                idEstacion = s.idEstacion,
                name = s.name,
                P_PunchSpeed = s.P_PunchSpeed,
                P_PunchDepth = s.P_PunchDepth,
                P_RadiusSpeed = s.P_RadiusSpeed,
                P_RadiusDepth = s.P_RadiusDepth,
                P_RadiusHoldTime = s.P_RadiusHoldTime,
                P_WeldTime = s.P_WeldTime,
                P_Energy = s.P_Energy,
                P_Amplitude = s.P_Amplitude,
                P_Frequency = s.P_Frequency,
                P_MaxPower = s.P_MaxPower,
            });

        }

        private bool PunchDataExists(int id)
        {
            return _context.PunchDatas.Any(e => e.id == id);
        }
    }
}
