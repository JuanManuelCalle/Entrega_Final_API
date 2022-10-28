using ConsignaFinal.Models;
using ConsignaFinal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioModificarController : ControllerBase
    {
        [HttpGet("{id}")]
        public List<Usuario> Perfil(int id)
        {
            return Ado_UsuarioModificacion.Perfil(id);
        }

        [HttpPost(Name = "Crear usuario")]
        public List<Usuario> CrearUsuario([FromBody] Usuario user)
        {
            return Ado_UsuarioModificacion.CrearUsuario(user);
        }

        [HttpPut(Name = "Editar usuario")]
        public List<Usuario> EditarUsuario([FromBody] Usuario user)
        {
            return Ado_UsuarioModificacion.EditarUsuario(user);
        }

        [HttpDelete(Name = "Eliminar usuario")]
        public List<Usuario> EliminarUsuario([FromBody] int id)
        {
            return Ado_UsuarioModificacion.EliminarUsuario(id);
        }
    }
}
