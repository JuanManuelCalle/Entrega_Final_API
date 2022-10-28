using ConsignaFinal.Models;
using ConsignaFinal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TraerProductosIdController : ControllerBase
    {
        [HttpGet("{id}")]
        public List<Producto> TraerProductosCargadosPorUsuario(int id)
        {
            return Ado_Producto.TraerProductoUsuario(id);
        }
    }
}
