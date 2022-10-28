using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsignaFinal.Models;
using Microsoft.Data.SqlClient;
using ConsignaFinal.Repository;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscarUsuarioGET : ControllerBase
    {
        [HttpGet("{id}")]
        public List<Usuario> GetUsuarioId(int id)
        {
            return Ado_Usuario.BuscarPorId(id);
        }
    }
}
