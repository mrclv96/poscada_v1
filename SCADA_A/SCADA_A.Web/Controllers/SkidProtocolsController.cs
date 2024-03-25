using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.OEE;
using SCADA_A.Web.Models.OEE.SkidProtocol;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkidProtocolsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public SkidProtocolsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/SkidProtocols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SkidProtocol>>> GetSkidProtocols()
        {
            return await _context.SkidProtocols.ToListAsync();
        }

        // GET: api/Skidprotocols/GetLastSkids
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<SkidViewModel>>> GetLastSkids()
        {
            var protocolsWithPos1 = await _context.SkidProtocols
                .OrderByDescending(e => e.DateAndTimeIN)
                .Where(e => e.Position == 1)
                .Take(1000)
                .ToListAsync();

            var labelIds = protocolsWithPos1.Select(e => e.LabelID).ToList();

            var SkidProtocol = await _context.SkidProtocols
                .Where(e => labelIds.Contains(e.LabelID))
                .ToListAsync();

            var SkidList = SkidProtocol
                .GroupBy(e => e.LabelID)
                .Select(group => group.OrderByDescending(e => e.DateAndTimeIN).FirstOrDefault())
                .Select(e => new SkidViewModel
                {
                    LabelID = e.LabelID,
                    Position = e.Position,
                    OrderName = e.OrderName,
                    OrderRef = e.OrderRef,
                    Skid_Number = e.Skid_Number,
                    TypeLab = e.TypeLab,
                    ColorLab = e.ColorLab,
                    PrimerLab = e.PrimerLab,
                    ClearLab = e.ClearLab,
                    VariantNo = e.VariantNo,
                    PitchVar = e.PitchVar,
                    QTY1 = e.QTY1,
                    QTY2 = e.QTY2,
                    PartSide1 = e.PartSide1,
                    PartSide2 = e.PartSide2,
                    CO2 = e.CO2,
                    Flaming = e.Flaming,
                    Basecoat = e.Basecoat,
                    DateAndTimeIN = e.DateAndTimeIN
                })
                .ToList(); // Convertir el resultado a una lista

            return Ok(new { SkidList, SkidProtocol });
        }

        // GET: api/Skidprotocols/GetSkidsFromDate/{date: format'yyyy-MM-dd'}
        [HttpGet("[action]/{date}")]
        public async Task<ActionResult<IEnumerable<SkidViewModel>>> GetSkidsFromDate(string date)
        {
            DateTime dateParsed;
            if (!DateTime.TryParseExact(date, "yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.None, out dateParsed))
            {
                return BadRequest("Mal formato de fecha. La fecha debe tener un formato yyyy-MM-dd");
            }

            var protocolsWithPos1 = await _context.SkidProtocols
                .Where(e => e.DateAndTimeIN.Date == dateParsed.Date && e.Position == 1)
                .ToListAsync();

            if (protocolsWithPos1 == null || protocolsWithPos1.Count == 0)
            {
                return NotFound("No se encontraron registros de esta fecha");
            }

            var labelIds = protocolsWithPos1.Select(e => e.LabelID).ToList();

            var SkidProtocol = await _context.SkidProtocols
                .Where(e => labelIds.Contains(e.LabelID))
                .ToListAsync();

            var SkidList = SkidProtocol
                .GroupBy(e => e.LabelID)
                .Select(group => group.OrderByDescending(e => e.DateAndTimeIN).FirstOrDefault())
                .Select(e => new SkidViewModel
                {
                    LabelID = e.LabelID,
                    Position = e.Position,
                    OrderName = e.OrderName,
                    OrderRef = e.OrderRef,
                    Skid_Number = e.Skid_Number,
                    TypeLab = e.TypeLab,
                    ColorLab = e.ColorLab,
                    PrimerLab = e.PrimerLab,
                    ClearLab = e.ClearLab,
                    VariantNo = e.VariantNo,
                    PitchVar = e.PitchVar,
                    QTY1 = e.QTY1,
                    QTY2 = e.QTY2,
                    PartSide1 = e.PartSide1,
                    PartSide2 = e.PartSide2,
                    CO2 = e.CO2,
                    Flaming = e.Flaming,
                    Basecoat = e.Basecoat,
                    DateAndTimeIN = e.DateAndTimeIN
                });

            return Ok(new { SkidList, SkidProtocol });
        }

        // GET: api/Skidprotocols/GetSkidByLabelID/{LabelID}
        [HttpGet("[action]/{labelID}")]
        public async Task<ActionResult<SkidViewModel>> GetSkidByLabelID(int labelID)
        {
            var skidProtocol = await _context.SkidProtocols
                .Where(e => e.LabelID == labelID)
                .OrderByDescending(e => e.DateAndTimeIN)
                .ToListAsync();

            if (skidProtocol.Count == 0)
            {
                return NotFound("No se encontraron registros con este LabelID");
            }

            var skid = new SkidViewModel
            {
                LabelID = skidProtocol[0].LabelID,
                Position = skidProtocol[0].Position,
                OrderName = skidProtocol[0].OrderName,
                OrderRef = skidProtocol[0].OrderRef,
                Skid_Number = skidProtocol[0].Skid_Number,
                TypeLab = skidProtocol[0].TypeLab,
                ColorLab = skidProtocol[0].ColorLab,
                PrimerLab = skidProtocol[0].PrimerLab,
                ClearLab = skidProtocol[0].ClearLab,
                VariantNo = skidProtocol[0].VariantNo,
                PitchVar = skidProtocol[0].PitchVar,
                QTY1 = skidProtocol[0].QTY1,
                QTY2 = skidProtocol[0].QTY2,
                PartSide1 = skidProtocol[0].PartSide1,
                PartSide2 = skidProtocol[0].PartSide2,
                CO2 = skidProtocol[0].CO2,
                Flaming = skidProtocol[0].Flaming,
                Basecoat = skidProtocol[0].Basecoat,
                DateAndTimeIN = skidProtocol[0].DateAndTimeIN
            };

            return Ok(new { SkidList = new List<SkidViewModel> { skid }, SkidProtocol = skidProtocol });
        }

        // GET: api/Skidprotocols/GetSkidDetails/{LabelID}
        [HttpGet("[action]/{labelID}")]
        public async Task<ActionResult<IEnumerable<SkidDetailsViewModel>>> GetSkidDetails(int labelID)
        {
            var SkidDetails = await _context.SkidProtocols
                .Where(e => e.LabelID == labelID)
                .OrderBy(e => e.DateAndTimeIN)
                .ToListAsync();

            if (SkidDetails == null)
            {
                return NotFound(); // Devolver 404 si no se encuentra ningún registro
            }

            return Ok(SkidDetails);
        }
    }
}
