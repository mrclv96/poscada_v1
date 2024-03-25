using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.OEE;
using SCADA_A.Web.Models.OEE.Order_Skid_Data;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Order_Skid_DataController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public Order_Skid_DataController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Order_Skid_Data/Listar
        [Authorize(Roles = "Admin,Paint")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<Order_Skid_DataViewModel>> Listar()
        {
            var orderskiddata = await _context.Order_Skid_Datas
                .Include(o => o.app_colors)
                .OrderByDescending(o => o.labelID)
                .ToListAsync();

            return orderskiddata.Select(t => new Order_Skid_DataViewModel
            {
                DateTimeIn = t.DateTimeIn,
                Skid = t.Skid,
                OrderName = t.OrderName,
                Referencia = t.Referencia,
                ProductLab = t.ProductLab,
                Modelo = t.Modelo,
                PrimerLab = t.PrimerLab,
                Color = t.Color,
                ClearLab = t.ClearLab,
                CO2 = t.CO2,
                FL = t.FL,
                BC = t.BC,
                Lado = t.Lado,
                V = t.V,
                PitchVar = t.PitchVar,
                QTY1 = t.QTY1,
                QTY2 = t.QTY2,
                Status = t.Status,
                Comentario = t.Comentario,
                labelID = t.labelID,
                Ubicacion = t.Ubicacion,

                RGBHex = t.app_colors.RGBHex,

            });
            ;
        }

        private bool Order_Skid_DataExists(DateTime id)
        {
            return _context.Order_Skid_Datas.Any(e => e.DateTimeIn == id);
        }
    }
}
