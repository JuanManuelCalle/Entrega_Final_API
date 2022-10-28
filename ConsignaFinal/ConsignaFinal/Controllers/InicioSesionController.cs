using ConsignaFinal.Models;
using ConsignaFinal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InicioSesionController : ControllerBase
    {
        [HttpGet("{usuario}/{contrasena}")]
        public List<Usuario> Login(string usuario, string contrasena)
        {
            return Ado_UsuarioModificacion.Login(usuario,contrasena);
        }
    }
}
