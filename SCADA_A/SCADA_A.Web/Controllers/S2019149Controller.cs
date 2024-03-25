using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Productos;
using SCADA_A.Entidades.TPL;
using SCADA_A.Web.Models.Produccion.Protocolo;
using SCADA_A.Web.Models.TPL;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering,Maintenance,Supervisor")]
    [Route("api/[controller]")]
    [ApiController]
    public class S2019149Controller : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public S2019149Controller(DbContextSCADA_A context)
        {
            _context = context;
        }
        // GET: api/S2019149/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<S2019149ViewModel>> Listar()
        {
            var temp = await _context.S2019149s
                //.Include(t => t.protocolo)
                .Take(100)
                .ToListAsync();

            return temp.Select(t => new S2019149ViewModel
            {
                idProtocolo = t.idProtocolo,
                F_BumperScan = t.F_BumperScan,
                F_Picktolightsensors = t.F_Picktolightsensors,
                F_LPtypeECE = t.F_LPtypeECE,
                F_LPtypeCameraSAM = t.F_LPtypeCameraSAM,
                F_LPtypeCameraECE = t.F_LPtypeCameraECE,
                F_LPtypeCameraSWI = t.F_LPtypeCameraSWI,
                F_LPtypeECEwithNAV = t.F_LPtypeECEwithNAV,
                F_LPtypeSAM = t.F_LPtypeSAM,
                F_LPtypeSAMwithAV = t.F_LPtypeSAMwithAV,
                F_LPtypeSchweizWithAV = t.F_LPtypeSchweizWithAV,
                F_LPtypePATaiwan = t.F_LPtypePATaiwan,
                F_LPtypeRLineTaiwan = t.F_LPtypeRLineTaiwan,
                F_Glue = t.F_Glue,
                Fk_BumperScan = t.Fk_BumperScan,
                Fk_Picktolightsensors = t.Fk_Picktolightsensors,
                Fk_LPtypeECE = t.Fk_LPtypeECE,
                Fk_LPtypeCameraSAM = t.Fk_LPtypeCameraSAM,
                Fk_LPtypeCameraECE = t.Fk_LPtypeCameraECE,
                Fk_LPtypeCameraSWI = t.Fk_LPtypeCameraSWI,
                Fk_LPtypeECEwithNAV = t.Fk_LPtypeECEwithNAV,
                Fk_LPtypeSAM = t.Fk_LPtypeSAM,
                Fk_LPtypeSAMwithAV = t.Fk_LPtypeSAMwithAV,
                Fk_LPtypeSchweizWithAV = t.Fk_LPtypeSchweizWithAV,
                Fk_LPtypePATaiwan = t.Fk_LPtypePATaiwan,
                Fk_LPtypeRLineTaiwan = t.Fk_LPtypeRLineTaiwan,
                Fk_Glue = t.Fk_Glue,
                P_LicensePlateScan = t.P_LicensePlateScan,
                P_GluePressure = t.P_GluePressure,
                P_GlueTime = t.P_GlueTime,
            });
            ;
        }
        // GET: api/S2019149/Select/05
        [HttpGet("[action]/{idProtocolo}")]
        public async Task<IEnumerable<S2019149ViewModel>> Select([FromRoute] int idProtocolo)
        {

            var temp = await _context.S2019149s
                .Where(s => s.idProtocolo == idProtocolo)
                .ToListAsync();


            return temp.Select(t => new S2019149ViewModel
            {
                idProtocolo = t.idProtocolo,
                F_BumperScan = t.F_BumperScan,
                F_Picktolightsensors = t.F_Picktolightsensors,
                F_LPtypeECE = t.F_LPtypeECE,
                F_LPtypeCameraSAM = t.F_LPtypeCameraSAM,
                F_LPtypeCameraECE = t.F_LPtypeCameraECE,
                F_LPtypeCameraSWI = t.F_LPtypeCameraSWI,
                F_LPtypeECEwithNAV = t.F_LPtypeECEwithNAV,
                F_LPtypeSAM = t.F_LPtypeSAM,
                F_LPtypeSAMwithAV = t.F_LPtypeSAMwithAV,
                F_LPtypeSchweizWithAV = t.F_LPtypeSchweizWithAV,
                F_LPtypePATaiwan = t.F_LPtypePATaiwan,
                F_LPtypeRLineTaiwan = t.F_LPtypeRLineTaiwan,
                F_Glue = t.F_Glue,
                Fk_BumperScan = t.Fk_BumperScan,
                Fk_Picktolightsensors = t.Fk_Picktolightsensors,
                Fk_LPtypeECE = t.Fk_LPtypeECE,
                Fk_LPtypeCameraSAM = t.Fk_LPtypeCameraSAM,
                Fk_LPtypeCameraECE = t.Fk_LPtypeCameraECE,
                Fk_LPtypeCameraSWI = t.Fk_LPtypeCameraSWI,
                Fk_LPtypeECEwithNAV = t.Fk_LPtypeECEwithNAV,
                Fk_LPtypeSAM = t.Fk_LPtypeSAM,
                Fk_LPtypeSAMwithAV = t.Fk_LPtypeSAMwithAV,
                Fk_LPtypeSchweizWithAV = t.Fk_LPtypeSchweizWithAV,
                Fk_LPtypePATaiwan = t.Fk_LPtypePATaiwan,
                Fk_LPtypeRLineTaiwan = t.Fk_LPtypeRLineTaiwan,
                Fk_Glue = t.Fk_Glue,
                P_LicensePlateScan = t.P_LicensePlateScan,
                P_GluePressure = t.P_GluePressure,
                P_GlueTime = t.P_GlueTime,
            });
            
            
        }

        private bool S2019149Exists(int id)
        {
            return _context.S2019149s.Any(e => e.id == id);
        }
    }
}
