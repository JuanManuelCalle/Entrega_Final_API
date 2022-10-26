using ConsignaFinal.Models;
using ConsignaFinal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        [HttpGet("{id}")]
        public List<Venta> VentaUsuario(int id)
        {
            return Ado_Producto.VentaUsuario(id);
        }

        [HttpPut(Name = "Modificar Producto")]
        public void EditarProducto([FromBody] Producto produ)
        {
            Ado_Producto.EditarProducto(produ);
        }

        [HttpDelete(Name = "Eliminar Producto")]
        public void EliminarProducto([FromBody] int id)
        {
            Ado_Producto.EliminarProducto(id);
        }

    }
}

