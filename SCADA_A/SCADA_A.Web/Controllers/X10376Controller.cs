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
    public class X10376Controller : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public X10376Controller(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/X10376/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<X10376ViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.X10376s
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(s => new X10376ViewModel
            {
                idProtocolo = s.idProtocolo,
                F_AssemblyFasciaSelected = s.F_AssemblyFasciaSelected,
                F_PLASensorSelected = s.F_PLASensorSelected,
                F_PDCSensorSelected = s.F_PDCSensorSelected,
                F_LHDampingSelected = s.F_LHDampingSelected,
                F_RHDampingSelected = s.F_RHDampingSelected,
                F_UNutSelected = s.F_UNutSelected,
                F_VIPSensorSelected = s.F_VIPSensorSelected,
                F_HernessSelected = s.F_HernessSelected,
                F_AssemblyFasciaScanned = s.F_AssemblyFasciaScanned,
                F_HernessScanned = s.F_HernessScanned,
                F_ColorScanned = s.F_ColorScanned,
                F_PLASensorPTL = s.F_PLASensorPTL,
                F_PDCSensorPTL = s.F_PDCSensorPTL,
                F_VIPSensorPTL = s.F_VIPSensorPTL,
                F_HernessPTL = s.F_HernessPTL,
                F_PLASensorETest = s.F_PLASensorETest,
                F_PDCSensorETest = s.F_PDCSensorETest,
                F_VIPSensorETest = s.F_VIPSensorETest,
                F_LHDampingCamInsp = s.F_LHDampingCamInsp,
                F_RHDampingCamInsp = s.F_RHDampingCamInsp,
                F_VIPSensorCamInsp = s.F_VIPSensorCamInsp,
                F_VIPSensorWetOut = s.F_VIPSensorWetOut,
                Fk_AssemblyFasciaSelected = s.Fk_AssemblyFasciaSelected,
                Fk_PLASensorSelected = s.Fk_PLASensorSelected,
                Fk_PDCSensorSelected = s.Fk_PDCSensorSelected,
                Fk_LHDampingSelected = s.Fk_LHDampingSelected,
                Fk_RHDampingSelected = s.Fk_RHDampingSelected,
                Fk_UNutSelected = s.Fk_UNutSelected,
                Fk_VIPSensorSelected = s.Fk_VIPSensorSelected,
                Fk_HernessSelected = s.Fk_HernessSelected,
                Fk_AssemblyFasciaScanned = s.Fk_AssemblyFasciaScanned,
                Fk_HernessScanned = s.Fk_HernessScanned,
                Fk_ColorScanned = s.Fk_ColorScanned,
                Fk_PLASensorPTL = s.Fk_PLASensorPTL,
                Fk_PDCSensorPTL = s.Fk_PDCSensorPTL,
                Fk_VIPSensorPTL = s.Fk_VIPSensorPTL,
                Fk_HernessPTL = s.Fk_HernessPTL,
                Fk_PLASensorETest = s.Fk_PLASensorETest,
                Fk_PDCSensorETest = s.Fk_PDCSensorETest,
                Fk_VIPSensorETest = s.Fk_VIPSensorETest,
                Fk_LHDampingCamInsp = s.Fk_LHDampingCamInsp,
                Fk_RHDampingCamInsp = s.Fk_RHDampingCamInsp,
                Fk_VIPSensorCamInsp = s.Fk_VIPSensorCamInsp,
                Fk_VIPSensorWetOut = s.Fk_VIPSensorWetOut,
                P_WetOut_Test = s.P_WetOut_Test,


            });
        }

        private bool X10376Exists(int id)
        {
            return _context.X10376s.Any(e => e.id == id);
        }
    }
}
