using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SCADA_A.Datos;
using SCADA_A.Entidades.Usuarios;
using SCADA_A.Web.Models.Usuarios.Rol;

namespace SCADA_A.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        public RolesController(DbContextSCADA_A context)
        {
            _context = context;
        }

        // GET: api/Roles/Listar
        [HttpGet("[action]")]
        public async Task<IEnumerable<RolViewModel>> Listar()
        {
            var rol = await _context.Roles.ToListAsync();

            return rol.Select(r => new RolViewModel
            {
                IdRol = r.IdRol,
                Nombre = r.Nombre,
                Descripcion = r.Descripcion,
                Estatus = r.Estatus

            });
        }

        // GET: api/Roles/Select
        [HttpGet("[action]")]
        public async Task<IEnumerable<SelectViewModel>> Select()
        {
            var rol = await _context.Roles.Where(r => r.Estatus == true).ToListAsync();

            return rol.Select(r => new SelectViewModel
            {
                IdRol = r.IdRol,
                Nombre = r.Nombre,

            });
        }

        private bool RolExists(int id)
        {
            return _context.Roles.Any(e => e.IdRol == id);
        }
    }
}
