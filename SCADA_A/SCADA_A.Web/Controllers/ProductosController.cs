using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Productos;
using SCADA_A.Entidades.Estaciones;
using SCADA_A.Web.Models.Productos.Producto;
using Microsoft.AspNetCore.Authorization;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin,Engineering")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public ProductosController(DbContextSCADA_A context)
        {
            _context = context;
        }


        // GET: api/Productos/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<ProductoViewModel>> Listar()
        {
            var producto = await _context.Productos
                .Include(i => i.secuencia)
                .Include(i => i.secuencia.linea)
                .Include(i => i.fascia)
                .ToListAsync();

            return producto.Select(i => new ProductoViewModel
            {
                idProducto = i.idProducto,
                idFascia = i.idFascia,
                idSecuencia = i.idSecuencia,
                Nombre = i.fascia.NombreVersion,
                Posicion0 = i.fascia.ModeloM100Pos0,
                Version = i.fascia.VersionM100Pos0,
                Linea = i.secuencia.linea.Nombre,
                Secuencia = i.secuencia.Flujo,
                Variante = i.Variante,
                Estatus = i.Estatus,

            });
        }

        // GET: api/Productos/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var producto = await _context.Productos
                .Include(i => i.secuencia)
                .Include(i => i.fascia)
                .Where(c => c.Estatus == true)
                .ToListAsync();

            return producto.Select(i => new SelectViewModel
            {
                idProducto = i.idProducto,
                Nombre = i.fascia.NombreVersion,
                Posicion0 = i.fascia.ModeloM100Pos0,
                Version = i.fascia.VersionM100Pos0,
                Variante = i.Variante,
            });
        }

        // GET: api/Productos/Mostrar/1
        [HttpGet("[action]/{id}")]
        public async Task<ActionResult<Producto>> Mostrar([FromRoute] int id)
        {
            var producto = await _context.Productos
                .Include(i => i.secuencia)
                .Include(i => i.fascia)
                .SingleOrDefaultAsync(a => a.idProducto == id);
           
            if (producto == null)
            {
                return NotFound();
            }

            return Ok(new ProductoViewModel
            {
                idProducto = producto.idProducto,
                idFascia = producto.idFascia,
                idSecuencia = producto.idSecuencia,
                Nombre = producto.fascia.NombreVersion,
                Posicion0 = producto.fascia.ModeloM100Pos0,
                Version = producto.fascia.VersionM100Pos0,
                //Linea = producto.secuencia.linea.Nombre,
                Secuencia = producto.secuencia.Flujo,
                Variante = producto.Variante,
                Estatus = producto.Estatus,
            });
        }

        // PUT: api/Productos/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idProducto <= 0)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(a => a.idProducto == model.idProducto);

            if (producto == null)
            {
                return NotFound();
            }

            producto.idProducto = model.idProducto;
            producto.idFascia = model.idFascia;
            producto.idSecuencia = model.idSecuencia;
            producto.Variante = model.Variante;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Producto - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // POST: api/Productos/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<ActionResult<Producto>> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Producto producto = new Producto
            {
                idFascia = model.idFascia,
                idSecuencia = model.idSecuencia,
                Variante = model.Variante,
                Estatus = true,
            };

            _context.Productos.Add(producto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Producto - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // DELETE: api/Productos/Eliminar/
        [Authorize(Roles = "Admin")]
        [HttpDelete("[action]/{id}")]
        public async Task<IActionResult> Eliminar([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var producto = await _context.Productos.FindAsync(id);
            if (producto == null)
            {
                return NotFound();
            }

            _context.Productos.Remove(producto);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(ex, "Producto - Eliminar");
                return BadRequest();
            }

            return Ok(producto);
        }

        // PUT: api/Productos/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(a => a.idProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Producto - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Productos/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var producto = await _context.Productos.FirstOrDefaultAsync(a => a.idProducto == id);

            if (producto == null)
            {
                return NotFound();
            }

            producto.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Producto - Desactivar");
                return BadRequest();
            }

            return Ok();
        }

        private bool ProductoExists(int id)
        {
            return _context.Productos.Any(e => e.idProducto == id);
        }
    }
}
