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
    public class S10923MController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S10923MController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/S10923M/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S10923MViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S10923Ms
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S10923MViewModel
            {
                idProtocolo = s.idProtocolo,
                F_UpperFasciaSelected = s.F_UpperFasciaSelected,
                F_LowerFasciaSelected = s.F_LowerFasciaSelected,
                F_LateralCoverLHSelected = s.F_LateralCoverLHSelected,
                F_LateralCoverRHSelected = s.F_LateralCoverRHSelected,
                F_LateralTrimLHSelected = s.F_LateralTrimLHSelected,
                F_LateralTrimRHSelected = s.F_LateralTrimRHSelected,
                F_ChromeStripSelected = s.F_ChromeStripSelected,
                F_CenterStripSelected = s.F_CenterStripSelected,
                F_TrimLowerSelected = s.F_TrimLowerSelected,
                F_TecBracketSelected = s.F_TecBracketSelected,
                F_TechInfSelected = s.F_TechInfSelected,
                F_PushPinsSelected = s.F_PushPinsSelected,
                F_ColorScanned = s.F_ColorScanned,
                F_TecBracketPTL = s.F_TecBracketPTL,
                F_TechInfPTL = s.F_TechInfPTL,
                Fk_UpperFasciaSelected = s.Fk_UpperFasciaSelected,
                Fk_LowerFasciaSelected = s.Fk_LowerFasciaSelected,
                Fk_LateralCoverLHSelected = s.Fk_LateralCoverLHSelected,
                Fk_LateralCoverRHSelected = s.Fk_LateralCoverRHSelected,
                Fk_LateralTrimLHSelected = s.Fk_LateralTrimLHSelected,
                Fk_LateralTrimRHSelected = s.Fk_LateralTrimRHSelected,
                Fk_ChromeStripSelected = s.Fk_ChromeStripSelected,
                Fk_CenterStripSelected = s.Fk_CenterStripSelected,
                Fk_TrimLowerSelected = s.Fk_TrimLowerSelected,
                Fk_TecBracketSelected = s.Fk_TecBracketSelected,
                Fk_TechInfSelected = s.Fk_TechInfSelected,
                Fk_PushPinsSelected = s.Fk_PushPinsSelected,
                Fk_ColorScanned = s.Fk_ColorScanned,
                Fk_TecBracketPTL = s.Fk_TecBracketPTL,
                Fk_TechInfPTL = s.Fk_TechInfPTL,



            });


        }

        private bool S10923MExists(int id)
        {
            return _context.S10923Ms.Any(e => e.id == id);
        }
    }
}
