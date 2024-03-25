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
    public class S10924MController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S10924MController(DbContextSCADA_A context)
        {
            _context = context;
        }


        // GET: api/S10924M/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S10924MViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S10924Ms
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S10924MViewModel
            {
                idProtocolo = s.idProtocolo,
                F_UpperFasciaSelected = s.F_UpperFasciaSelected,
                F_LowerFasciaSelected = s.F_LowerFasciaSelected,
                F_OutterLHReflectorSelected = s.F_OutterLHReflectorSelected,
                F_InnerLHReflectorSelected = s.F_InnerLHReflectorSelected,
                F_OutterRHReflectorSelected = s.F_OutterRHReflectorSelected,
                F_InnerRHReflectorSelected = s.F_InnerRHReflectorSelected,
                F_UpperChromeBlackSelected = s.F_UpperChromeBlackSelected,
                F_TecBracketSelected = s.F_TecBracketSelected,
                F_CenterCoverSelected = s.F_CenterCoverSelected,
                F_ExhaustPipSelected = s.F_ExhaustPipSelected,
                F_MiddleReflectorSelected = s.F_MiddleReflectorSelected,
                F_DiffuserSelected = s.F_DiffuserSelected,
                F_UpperFasciaScanned = s.F_UpperFasciaScanned,
                F_ColorScanned = s.F_ColorScanned,
                Fk_UpperFasciaSelected = s.Fk_UpperFasciaSelected,
                Fk_LowerFasciaSelected = s.Fk_LowerFasciaSelected,
                Fk_OutterLHReflectorSelected = s.Fk_OutterLHReflectorSelected,
                Fk_InnerLHReflectorSelected = s.Fk_InnerLHReflectorSelected,
                Fk_OutterRHReflectorSelected = s.Fk_OutterRHReflectorSelected,
                Fk_InnerRHReflectorSelected = s.Fk_InnerRHReflectorSelected,
                Fk_UpperChromeBlackSelected = s.Fk_UpperChromeBlackSelected,
                Fk_TecBracketSelected = s.Fk_TecBracketSelected,
                Fk_CenterCoverSelected = s.Fk_CenterCoverSelected,
                Fk_ExhaustPipSelected = s.Fk_ExhaustPipSelected,
                Fk_MiddleReflectorSelected = s.Fk_MiddleReflectorSelected,
                Fk_DiffuserSelected = s.Fk_DiffuserSelected,
                Fk_UpperFasciaScanned = s.Fk_UpperFasciaScanned,
                Fk_ColorScanned = s.Fk_ColorScanned,

            });


        }

        private bool S10924MExists(int id)
        {
            return _context.S10924Ms.Any(e => e.id == id);
        }
    }
}
