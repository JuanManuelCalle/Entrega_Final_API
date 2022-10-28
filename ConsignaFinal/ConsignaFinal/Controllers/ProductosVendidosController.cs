using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ConsignaFinal.Repository;
using ConsignaFinal.Models;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosVendidosController : ControllerBase
    {
        [HttpGet("{id}")]
        public List<ProductosVendidos> TraerProductosVendidos(int id)
        {
            return Ado_Producto.TraerProductosVendidosUsuario(id);
        }
    }
}
