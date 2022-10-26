namespace ConsignaFinal.Models
{
    public class ProductosVendidos
    {
        public int Id { get; set; }
        public int Stock { get; set; }
        public int IdProducto { get; set; }

        public ProductosVendidos()
        {
            Id = 0;
            Stock = 0;
            IdProducto = 0;
        }
    }
}
