using APIRestIndotInventarioMovil.DTO;
using APIRestIndotInventarioMovil.Models;
using APIRestIndotInventarioMovil.Services;
using APIRestIndotInventarioMovil.Utils;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace APIRestIndotInventarioMovil.Controllers
{
    [Route("/apiinventariomovil")]
    [ApiController]
    public class LoginAPIController : ControllerBase
    {
        private readonly IServicioSupabase _servicioSupabase;
        private readonly IConfiguration _configuration;
        public LoginAPIController(IServicioSupabase servicioSupabase, IConfiguration configuration)
        {
            _servicioSupabase = servicioSupabase; 
            _configuration = configuration;
        }
        [Route("/login")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UsuarioApiDTO>> Login(LoginAPI usuarioLogin)
        {
            Usuario Usuario = null;
            Usuario = await AutenticarUsuarioAsync(usuarioLogin);
            if (Usuario == null)
                throw new Exception("Credenciales no válidas");
            else
                Usuario = GenerarTokenJWT(Usuario);

                return Usuario.convertirDTO();
        }

        private async Task<Usuario> AutenticarUsuarioAsync(LoginAPI usuarioLogin)
        {
            Usuario usuarioSupabase = await _servicioSupabase.DameUsuarioSupabase (usuarioLogin); //Login con base datos remota Supabase
            
            return usuarioSupabase;
        }

        private Usuario GenerarTokenJWT(Usuario usuarioSupabase)
        {
            // Cabecera
            var _symmetricSecurityKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["JWT:ClaveSecreta"])
                );
            var _signingCredentials = new SigningCredentials(
                    _symmetricSecurityKey, SecurityAlgorithms.HmacSha256 // Establecer cifrado en función
                                                                         // de la longitud de clave secreta en appSettings.json
                );
            var _Header = new JwtHeader(_signingCredentials);
            // Claims
            var _Claims = new[] {
                new Claim("Email", usuarioSupabase.Email),
                new Claim("Nombre", usuarioSupabase.Nombre),
                new Claim(JwtRegisteredClaimNames.Email, usuarioSupabase.Email),
            };

            //Payload
            var _Payload = new JwtPayload(
                    issuer: _configuration["JWT:Issuer"],
                    audience: _configuration["JWT:Audience"],
                    claims: _Claims,
                    notBefore: DateTime.UtcNow,
                    expires: DateTime.UtcNow.AddMinutes(60) //Minutos de caducidad del Token
                );

            // Token
            var _Token = new JwtSecurityToken(
                    _Header,
                    _Payload
                );

            usuarioSupabase.Token = new JwtSecurityTokenHandler().WriteToken(_Token);

            return usuarioSupabase;
        }
    }
}
