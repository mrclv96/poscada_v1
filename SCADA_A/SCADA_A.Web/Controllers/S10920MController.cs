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
    public class S10920MController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S10920MController(DbContextSCADA_A context)
        {
            _context = context;
        }
        // GET: api/S10920M/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S10920MViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S10920Ms
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S10920MViewModel
            {
                idProtocolo = s.idProtocolo,
                F_UpperFasciaSelected = s.F_UpperFasciaSelected,
                F_LowerFasciaSelected = s.F_LowerFasciaSelected,
                F_LHLateralCoverSelected = s.F_LHLateralCoverSelected,
                F_RHLateralCoverSelected = s.F_RHLateralCoverSelected,
                F_LHLateralFinisherSelected = s.F_LHLateralFinisherSelected,
                F_RHLateralFinisherSelected = s.F_RHLateralFinisherSelected,
                F_UnderRideSelected = s.F_UnderRideSelected,
                F_TecBracketSelected = s.F_TecBracketSelected,
                F_TopLineTrimSelected = s.F_TopLineTrimSelected,
                F_MiddleTrimSelected = s.F_MiddleTrimSelected,
                F_TechInfSelected = s.F_TechInfSelected,
                F_LowerFasciaScanned = s.F_LowerFasciaScanned,
                F_LHLateralCoverScanned = s.F_LHLateralCoverScanned,
                F_RHLateralCoverScanned = s.F_RHLateralCoverScanned,
                F_ColorScanned = s.F_ColorScanned,
                F_MiddleTrimScanned = s.F_MiddleTrimScanned,
                F_LHLateralFinisherPTL = s.F_LHLateralFinisherPTL,
                F_RHLateralFinisherPTL = s.F_RHLateralFinisherPTL,
                F_TecBracketPTL = s.F_TecBracketPTL,
                F_TechInfPTL = s.F_TechInfPTL,
                Fk_UpperFasciaSelected = s.Fk_UpperFasciaSelected,
                Fk_LowerFasciaSelected = s.Fk_LowerFasciaSelected,
                Fk_LHLateralCoverSelected = s.Fk_LHLateralCoverSelected,
                Fk_RHLateralCoverSelected = s.Fk_RHLateralCoverSelected,
                Fk_LHLateralFinisherSelected = s.Fk_LHLateralFinisherSelected,
                Fk_RHLateralFinisherSelected = s.Fk_RHLateralFinisherSelected,
                Fk_UnderRideSelected = s.Fk_UnderRideSelected,
                Fk_TecBracketSelected = s.Fk_TecBracketSelected,
                Fk_TopLineTrimSelected = s.Fk_TopLineTrimSelected,
                Fk_MiddleTrimSelected = s.Fk_MiddleTrimSelected,
                Fk_TechInfSelected = s.Fk_TechInfSelected,
                Fk_LowerFasciaScanned = s.Fk_LowerFasciaScanned,
                Fk_LHLateralCoverScanned = s.Fk_LHLateralCoverScanned,
                Fk_RHLateralCoverScanned = s.Fk_RHLateralCoverScanned,
                Fk_ColorScanned = s.Fk_ColorScanned,
                Fk_MiddleTrimScanned = s.Fk_MiddleTrimScanned,
                Fk_LHLateralFinisherPTL = s.Fk_LHLateralFinisherPTL,
                Fk_RHLateralFinisherPTL = s.Fk_RHLateralFinisherPTL,
                Fk_TecBracketPTL = s.Fk_TecBracketPTL,
                Fk_TechInfPTL = s.Fk_TechInfPTL,

            });


        }

        private bool S10920MExists(int id)
        {
            return _context.S10920Ms.Any(e => e.id == id);
        }
    }
}
