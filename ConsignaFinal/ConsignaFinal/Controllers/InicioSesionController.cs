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
        [HttpPost(Name = "Login")]
        public List<Usuario> Login([FromBody] Login log)
        {
            return Ado_UsuarioModificacion.Login(log);
        }
    }
}
