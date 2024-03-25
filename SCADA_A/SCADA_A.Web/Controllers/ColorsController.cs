using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Colores;
using SCADA_A.Web.Models.Colores.Color;

namespace SCADA_A.Web.Controllers
{
 
    [Route("api/[controller]")]
    [ApiController]
    public class ColorsController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ColorsController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Colors/Listar
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]")]
        public async Task <IEnumerable<ColorViewModel>> Listar()
        {
            var color = await _context.Colores.ToListAsync();

            return color.Select(c => new ColorViewModel
            {
                CodigoColor = c.CodigoColor,
                Nombre = c.Nombre,
                RGBHex = c.RGBHex,
                Estatus = c.Estatus,

            });
        }
        // GET: api/Colors/Select
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var color = await _context.Colores.Where(c=>c.Estatus==true).ToListAsync();

            return color.Select(c => new SelectViewModel
            {
                CodigoColor = c.CodigoColor,
                Nombre = c.Nombre
            });
        }

        // GET: api/Colors/Mostrar/04
        [Authorize(Roles = "Admin,Engineering")]
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Color>> Mostrar([FromRoute] string id)
        {
            var color = await _context.Colores.FindAsync(id);

            if (color == null)
            {
                return NotFound();
            }

            return Ok (new ColorViewModel
            {
                CodigoColor = color.CodigoColor,
                Nombre = color.Nombre,
                RGBHex = color.RGBHex

            }); 
        }

        // PUT: api/Colors/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
                //return Problem("msg", statusCode: (int)HttpStatusCode.BadRequest, instance: string) ;
            }

            if (ColorExists(model.CodigoColor) is false)
            {
                return BadRequest();
            }

            var color = await _context.Colores.FirstOrDefaultAsync(c=> c.CodigoColor == model.CodigoColor);

            if (color == null)
            {
                return NotFound();
            }

            color.Nombre = model.Nombre;
            color.RGBHex = model.RGBHex;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Color - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Colors/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPost("[action]")]
        public async Task<ActionResult<Color>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Color color = new Color
            {
                CodigoColor = model.CodigoColor,
                Nombre = model.Nombre,
                RGBHex= model.RGBHex,
                Estatus = true,
            };

            _context.Colores.Add(color);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Color - Crear");
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Colors/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] string id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var color = await _context.Colores.FindAsync(id);
            if (color == null)
            {
                return NotFound();
            }

            _context.Colores.Remove(color);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Color - Eliminar");
                return BadRequest();
            }

            return Ok(color);
        }
        // PUT: api/Colors/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] string id)
        {

            if (id is null)
            {
                return BadRequest();
            }

            var color = await _context.Colores.FirstOrDefaultAsync(c => c.CodigoColor == id);

            if (color == null)
            {
                return NotFound();
            }

            color.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Color - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Colors/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] string id)
        {

            if (id is null)
            {
                return BadRequest();
            }

            var color = await _context.Colores.FirstOrDefaultAsync(c => c.CodigoColor == id);

            if (color == null)
            {
                return NotFound();
            }

            color.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Color - Desactivar");
                return BadRequest();
            }

            return Ok();
        }

        private bool ColorExists(string id)
        {
            return _context.Colores.Any(e => e.CodigoColor == id);
        }
    }
}
