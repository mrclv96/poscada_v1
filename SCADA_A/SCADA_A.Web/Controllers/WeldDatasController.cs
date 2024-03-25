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
    public class WeldDatasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public WeldDatasController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // POST: api/WeldDatas/Select/
        [HttpPost("[action]")]
        public async Task<IEnumerable<WeldDataViewModel>> Select([FromBody] EstacionProtocoloViewModel model)
        {

            var temp = await _context.WeldDatas
                .Where(s => s.idProtocolo == model.idProtocolo && s.idEstacion == model.idEstacion)
                .ToListAsync();

            return temp.Select(s => new WeldDataViewModel
            {
                idProtocolo = s.idProtocolo,
                idEstacion = s.idEstacion,
                name = s.name,
                P_Setpoint = s.P_Setpoint,
                P_Reached = s.P_Reached,
                P_Pressure = s.P_Pressure,
                P_CoolingTime = s.P_CoolingTime,
                P_AfterCoolTime = s.P_AfterCoolTime,
                P_WeldTime = s.P_WeldTime,
                P_Energy = s.P_Energy,
                P_Amplitude = s.P_Amplitude,
                P_Frequency = s.P_Frequency,
                P_MaxPower = s.P_MaxPower,

            });

        }

        private bool WeldDataExists(int id)
        {
            return _context.WeldDatas.Any(e => e.id == id);
        }
    }
}
