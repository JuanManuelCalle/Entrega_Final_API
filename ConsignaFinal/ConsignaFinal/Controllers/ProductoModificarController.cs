using ConsignaFinal.Models;
using ConsignaFinal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoModificarController : ControllerBase
    {
        [HttpPost]
        public void CrearProducto([FromBody] Producto productoCrear)
        {
            Ado_Producto.CrearProducto(productoCrear);
        }
    }
}
