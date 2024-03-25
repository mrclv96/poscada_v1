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
    public class S10921MController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S10921MController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/S10921M/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S10921MViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S10921Ms
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new S10921MViewModel
            {
                idProtocolo = s.idProtocolo,
                //idEstacion = s.idEstacion,
                F_UpperFasciaSelected = s.F_UpperFasciaSelected,
                F_SpoilerSelected = s.F_SpoilerSelected,
                F_UpperChromeSelected = s.F_UpperChromeSelected,
                F_MiddleReflectorSelected = s.F_MiddleReflectorSelected,
                F_ExhaustPipeFinisherSelected = s.F_ExhaustPipeFinisherSelected,
                F_DiffuserSelected = s.F_DiffuserSelected,
                F_TecBracketSelected = s.F_TecBracketSelected,
                F_LHOutReflectorSelected = s.F_LHOutReflectorSelected,
                F_LHInnReflectorSelected = s.F_LHInnReflectorSelected,
                F_RHOutReflectorSelected = s.F_RHOutReflectorSelected,
                F_RHInnReflectorSelected = s.F_RHInnReflectorSelected,
                F_UpperFasciaScanned = s.F_UpperFasciaScanned,
                F_SpoilerScanned = s.F_SpoilerScanned,
                F_ColorScanned = s.F_ColorScanned,
                Fk_UpperFasciaSelected = s.Fk_UpperFasciaSelected,
                Fk_SpoilerSelected = s.Fk_SpoilerSelected,
                Fk_UpperChromeSelected = s.Fk_UpperChromeSelected,
                Fk_MiddleReflectorSelected = s.Fk_MiddleReflectorSelected,
                Fk_ExhaustPipeFinisherSelected = s.Fk_ExhaustPipeFinisherSelected,
                Fk_DiffuserSelected = s.Fk_DiffuserSelected,
                Fk_TecBracketSelected = s.Fk_TecBracketSelected,
                Fk_LHOutReflectorSelected = s.Fk_LHOutReflectorSelected,
                Fk_LHInnReflectorSelected = s.Fk_LHInnReflectorSelected,
                Fk_RHOutReflectorSelected = s.Fk_RHOutReflectorSelected,
                Fk_RHInnReflectorSelected = s.Fk_RHInnReflectorSelected,
                Fk_UpperFasciaScanned = s.Fk_UpperFasciaScanned,
                Fk_SpoilerScanned = s.Fk_SpoilerScanned,
                Fk_ColorScanned = s.Fk_ColorScanned,


            });


        }

        private bool S10921MExists(int id)
        {
            return _context.S10921Ms.Any(e => e.id == id);
        }
    }
}
