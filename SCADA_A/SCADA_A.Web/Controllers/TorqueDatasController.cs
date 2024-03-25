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
    public class TorqueDatasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public TorqueDatasController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // POST: api/TorqueDatas/Select/
        [HttpPost("[action]")]
        public async Task<IEnumerable<TorqueDataViewModel>> Select([FromBody] EstacionProtocoloViewModel model)
        {

            var temp = await _context.TorqueDatas
                .Where(s => s.idProtocolo == model.idProtocolo && s.idEstacion == model.idEstacion)
                .ToListAsync();

            return temp.Select(s => new TorqueDataViewModel
            {
                idProtocolo = s.idProtocolo,
                idEstacion = s.idEstacion,
                IdSTA = s.IdSTA,
                NumTrq = s.NumTrq,
                NumTrqOK = s.NumTrqOK,
                name = s.name,

            });

        }

        private bool TorqueDataExists(int id)
        {
            return _context.TorqueDatas.Any(e => e.id == id);
        }
    }
}
