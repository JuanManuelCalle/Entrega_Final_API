using ConsignaFinal.Models;
using static ConsignaFinal.Controllers.UsuarioController;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsignaFinal.Repository
{
    public class Ado_Producto
    {     
        public static List<ProductosVendidos> TraerProductosVendidosUsuario(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listProductoVendido = new List<ProductosVendidos>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT p.IdUsuario, v.IdUsuario, pv.IdProducto, pv.IdVenta FROM Producto p INNER JOIN Venta v ON p.Id = v.Id INNER JOIN ProductoVendido pv ON pv.Id = p.Id WHERE p.IdUsuario = @IdUserVenta";

                    Convert.ToInt32(id);

                    var idUser = new SqlParameter();
                    idUser.ParameterName = "IdUserVenta";
                    idUser.SqlDbType = SqlDbType.BigInt;
                    idUser.Value = id;
                    cmd.Parameters.Add(idUser);


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var ProductoVendido = new ProductosVendidos();

                        ProductoVendido.Id = Convert.ToInt32(reader.GetValue(0));
                        ProductoVendido.Stock = Convert.ToInt32(reader.GetValue(1));
                        ProductoVendido.IdProducto = Convert.ToInt32(reader.GetValue(2));

                        listProductoVendido.Add(ProductoVendido);
                    }
                    reader.Close();
                    conexion.Close();

                    return listProductoVendido;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Venta> VentaUsuario(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var ListVenta = new List<Venta>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Venta WHERE IdUsuario = @IdUsuarioVenta";

                    Convert.ToInt32(id);

                    var IdUsuario = new SqlParameter();
                    IdUsuario.ParameterName = "IdUsuarioVenta";
                    IdUsuario.SqlDbType = SqlDbType.VarChar;
                    IdUsuario.Value = id;
                    cmd.Parameters.Add(IdUsuario);


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var venta = new Venta();

                        venta.Id = Convert.ToInt32(reader.GetValue(0));
                        venta.Comentarios = reader.GetValue(1).ToString();
                        venta.IdUsuario = Convert.ToInt32(reader.GetValue(2));

                        ListVenta.Add(venta);
                    }
                    reader.Close();
                    conexion.Close();

                    return ListVenta;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EditarProducto(Producto produ)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listProducto = new List<Producto>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @IdProducto ";

                    var Descripciones = new SqlParameter();
                    Descripciones.ParameterName = "Descripciones";
                    Descripciones.SqlDbType = SqlDbType.VarChar;
                    Descripciones.Value = produ.Descripciones;
                    cmd.Parameters.Add(Descripciones);

                    var Costo = new SqlParameter();
                    Costo.ParameterName = "Costo";
                    Costo.SqlDbType = SqlDbType.Money;
                    Costo.Value = produ.Costo;
                    cmd.Parameters.Add(Costo);

                    var PrecioVenta = new SqlParameter();
                    PrecioVenta.ParameterName = "PrecioVenta";
                    PrecioVenta.SqlDbType = SqlDbType.Money;
                    PrecioVenta.Value = produ.PrecioVenta;
                    cmd.Parameters.Add(PrecioVenta);

                    var Stock = new SqlParameter();
                    Stock.ParameterName = "Stock";
                    Stock.SqlDbType = SqlDbType.Int;
                    Stock.Value = produ.Stock;
                    cmd.Parameters.Add(Stock);

                    var IdUsuario = new SqlParameter();
                    IdUsuario.ParameterName = "IdUsuario";
                    IdUsuario.SqlDbType = SqlDbType.BigInt;
                    IdUsuario.Value = produ.IdUsuario;
                    cmd.Parameters.Add(IdUsuario);

                    var IdProducto = new SqlParameter();
                    IdProducto.ParameterName = "IdProducto";
                    IdProducto.SqlDbType = SqlDbType.BigInt;
                    IdProducto.Value = produ.Id;
                    cmd.Parameters.Add(IdProducto);

                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void EliminarProducto(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listProductos = new List<Producto>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "DELETE FROM Producto Where Id = @IdProducto";

                    Convert.ToInt32(id);

                    var IdUser = new SqlParameter();
                    IdUser.ParameterName = "IdProducto";
                    IdUser.SqlDbType = SqlDbType.BigInt;
                    IdUser.Value = id;
                    cmd.Parameters.Add(IdUser);

                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static void CrearProducto(Producto productoCrear)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listProducto = new List<Producto>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "INSERT INTO Producto(Descripciones,Costo,PrecioVenta,Stock,IdUsuario) VALUES (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario) ";

                    var Descripciones = new SqlParameter();
                    Descripciones.ParameterName = "Descripciones";
                    Descripciones.SqlDbType = SqlDbType.VarChar;
                    Descripciones.Value = productoCrear.Descripciones;
                    cmd.Parameters.Add(Descripciones);

                    var Costo = new SqlParameter();
                    Costo.ParameterName = "Costo";
                    Costo.SqlDbType = SqlDbType.Money;
                    Costo.Value = productoCrear.Costo;
                    cmd.Parameters.Add(Costo);

                    var PrecioVenta = new SqlParameter();
                    PrecioVenta.ParameterName = "PrecioVenta";
                    PrecioVenta.SqlDbType = SqlDbType.Money;
                    PrecioVenta.Value = productoCrear.PrecioVenta;
                    cmd.Parameters.Add(PrecioVenta);

                    var Stock = new SqlParameter();
                    Stock.ParameterName = "Stock";
                    Stock.SqlDbType = SqlDbType.Int;
                    Stock.Value = productoCrear.Stock;
                    cmd.Parameters.Add(Stock);

                    var IdUsuario = new SqlParameter();
                    IdUsuario.ParameterName = "IdUsuario";
                    IdUsuario.SqlDbType = SqlDbType.BigInt;
                    IdUsuario.Value = productoCrear.IdUsuario;
                    cmd.Parameters.Add(IdUsuario);


                    cmd.ExecuteNonQuery();

                    conexion.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Producto> TraerProductoUsuario(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var ListProducto = new List<Producto>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Producto WHERE IdUsuario = @IdUsuarioCargo";

                    Convert.ToInt32(id);

                    var IdCarga = new SqlParameter();
                    IdCarga.ParameterName = "IdUsuarioCargo";
                    IdCarga.SqlDbType = SqlDbType.BigInt;
                    IdCarga.Value = id;
                    cmd.Parameters.Add(IdCarga);


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var productos = new Producto();

                        productos.Id = Convert.ToInt32(reader.GetValue(0));
                        productos.Descripciones = reader.GetValue(1).ToString();
                        productos.Costo = Convert.ToInt32(reader.GetValue(2));
                        productos.PrecioVenta = Convert.ToInt32(reader.GetValue(2));
                        productos.Stock = Convert.ToInt32(reader.GetValue(2));

                        ListProducto.Add(productos);
                    }
                    reader.Close();
                    conexion.Close();

                    return ListProducto;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
