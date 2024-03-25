using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.TPL;

namespace SCADA_A.Web.Models.TPL
{
    [Route("api/[controller]")]
    [ApiController]
    public class ScanDatasController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ScanDatasController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // POST: api/ScanDatas/Select/
        [HttpPost("[action]")]
        public async Task<IEnumerable<ScanDataViewModel>> Select([FromBody] EstacionProtocoloViewModel model)
        {

            var temp = await _context.ScanDatas
                .Where(s => s.idProtocolo == model.idProtocolo && s.idEstacion == model.idEstacion)
                .ToListAsync();

            return temp.Select(s => new ScanDataViewModel
            {
                idProtocolo = s.idProtocolo,
                idEstacion = s.idEstacion,
                IdSTA = s.IdSTA,
                name = s.name,
                StringScan = s.StringScan,
                StringStep = s.StringStep,

            });

        }

        private bool ScanDataExists(int id)
        {
            return _context.ScanDatas.Any(e => e.id == id);
        }
    }
}
