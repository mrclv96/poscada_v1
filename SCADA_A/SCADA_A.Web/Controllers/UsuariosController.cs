
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SCADA_A.Datos;
using SCADA_A.Entidades.Usuarios;
using SCADA_A.Web.Models.Usuarios.Usuario;

namespace SCADA_A.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly DbContextSCADA_A _context;

        private readonly IConfiguration _config;

        public UsuariosController(DbContextSCADA_A context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        // GET: api/Usuarios/Listar
        [Authorize(Roles = "Admin")]
        [HttpGet("[action]")]
        public async Task<IEnumerable<UsuarioViewModel>> Listar()
        {
            var usuario = await _context.Usuarios
                .Include(i => i.rol)
                .ToListAsync();

            return usuario.Select(u => new UsuarioViewModel
            {
                idUsuario = u.idUsuario,
                idRol = u.idRol,
                Nombre = u.Nombre,
                Rol = u.rol.Nombre,
                PasswordHash = u.PasswordHash,
                Estatus = u.Estatus
            });
        }

        // POST: api/Usuarios/Crear
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPost("[action]")]
        public async Task<IActionResult> Crear([FromBody] CrearViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var nombre = model.Nombre.ToLower();
            if (await _context.Usuarios.AnyAsync(u=> u.Nombre == nombre))
            {
                return BadRequest("Ese nombre de usuario ya existe");
            }

            CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);

            Usuario usuario = new Usuario
            {
                idRol = model.idRol,
                Nombre = model.Nombre,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Estatus = true,
            };

            _context.Usuarios.Add(usuario);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Usuario - Crear");
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/Usuarios/Actualizar
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPut("[action]")]
        public async Task<IActionResult> Actualizar([FromBody] ActualizarViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idUsuario < 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.idUsuario == model.idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.idRol = model.idRol;
            usuario.Nombre = model.Nombre;

            if( model.actPassword == true)
            {
                CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;
            }


            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Usuario - Actualizar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Usuarios/CambiarPassword
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin,Engineering,Logistic,Maintenance,Supervisor,Paint")]
        [HttpPut("[action]")]
        public async Task<IActionResult> CambiarPassword([FromBody] CambiarPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (model.idUsuario < 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.idUsuario == model.idUsuario);

            if (usuario == null)
            {
                return NotFound();
            }

            if (model.actPassword == true)
            {
                CrearPasswordHash(model.Password, out byte[] passwordHash, out byte[] passwordSalt);
                usuario.PasswordHash = passwordHash;
                usuario.PasswordSalt = passwordSalt;
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Usuario - CambiarPassword");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Usuarios/Activar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Activar([FromRoute] int id)
        {

            if (id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(a => a.idUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Estatus = true;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Usuario - Activar");
                return BadRequest();
            }

            return Ok();
        }

        // PUT: api/Usuarios/Desactivar/1
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [Authorize(Roles = "Admin")]
        [HttpPut("[action]/{id}")]
        public async Task<IActionResult> Desactivar([FromRoute] int id)
        {

            if(id <= 0)
            {
                return BadRequest();
            }

            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.idUsuario == id);

            if (usuario == null)
            {
                return NotFound();
            }

            usuario.Estatus = false;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                DErrTrace errTrace = new DErrTrace();
                errTrace.ExErrTrace(e, "Usuario - Desactivar");
                return BadRequest();
            }

            return Ok();
        }
        // PUT: api/Usuarios/Login/
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            var usuario = await _context.Usuarios.Where(u => u.Estatus==true).Include(u => u.rol).FirstOrDefaultAsync(u => u.Nombre == model.nombre);

            if (usuario == null)
            {
                return NotFound();
            }

            if (!VerificarPasswordHash(model.password, usuario.PasswordHash, usuario.PasswordSalt))
            {
                return NotFound();
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.idUsuario.ToString()),
                new Claim(ClaimTypes.Name,usuario.Nombre),
                new Claim(ClaimTypes.Role,usuario.rol.Nombre),
                new Claim("idUsuario", usuario.idUsuario.ToString()),
                new Claim("Nombre",usuario.Nombre),
                new Claim("Rol",usuario.rol.Nombre),
            };

            return Ok(
                    new {token = GenerarToken(claims)}
                );


        }
        private string GenerarToken(List<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                expires: DateTime.Now.AddDays(30), //.AddMinutes(30),
                signingCredentials: creds,
                claims: claims);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        private void CrearPasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
        private bool VerificarPasswordHash(string password, byte[] passwordHashAlmacenado, byte[] passwordSalt)
        {
            using(var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var passwordHashNuevo = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return new ReadOnlySpan<byte>(passwordHashAlmacenado).SequenceEqual(new ReadOnlySpan<byte>(passwordHashNuevo));
            }
        }
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(e => e.idUsuario == id);
        }
    }
}
