using ConsignaFinal.Models;
using ConsignaFinal.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConsignaFinal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargarVentaNuevaController : ControllerBase
    {
        [HttpPost(Name = "Cargar Venta")]
        public void CargarVenta(List<ProductosVendidos> producto, string comentarios, int IdUsuario)
        {
            Ado_Venta.CargarVenta(producto, comentarios, IdUsuario);
        }

        [HttpGet("{id}")]
        public List<Venta> TraerVentasPorUsuario(int id)
        {
            return Ado_Venta.TraerVentas(id);
        }
    }
}
