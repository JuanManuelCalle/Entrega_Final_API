using ConsignaFinal.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsignaFinal.Repository
{
    public class Ado_Venta
    {
        public static void CargarVenta(List<ProductosVendidos> productos, string comentarios, int IdUsuario)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "INSERT INTO Venta(Comentarios,IdUsuario) VALUES (@Comentarios,@idUsuario); select @@IDENTITY";

                    var Comentarios = new SqlParameter();
                    Comentarios.ParameterName = "Comentarios";
                    Comentarios.SqlDbType = SqlDbType.VarChar;
                    Comentarios.Value = comentarios;
                    cmd.Parameters.Add(Comentarios);

                    var idUsuario = new SqlParameter();
                    idUsuario.ParameterName = "idUsuario";
                    idUsuario.SqlDbType = SqlDbType.VarChar;
                    idUsuario.Value = IdUsuario;
                    cmd.Parameters.Add(idUsuario);

                    int IdDeVenta = 0;
                    IdDeVenta = Convert.ToInt32(cmd.ExecuteScalar());

                    foreach (ProductosVendidos productosCargar in productos)
                    {
                        SqlCommand cmd2 = conexion.CreateCommand();
                        string queryInsert = "INSERT INTO ProductoVendido (Stock, IdProducto, idVenta) VALUES (@stock, @idProducto, @idVenta);";
                        cmd2 = new SqlCommand(queryInsert, conexion);

                        var Stock = new SqlParameter();
                        Stock.ParameterName = "stock";
                        Stock.SqlDbType = SqlDbType.BigInt;
                        Stock.Value = productosCargar.Stock;
                        cmd2.Parameters.Add(Stock);

                        var IdProducto = new SqlParameter();
                        IdProducto.ParameterName = "idProducto";
                        IdProducto.SqlDbType = SqlDbType.BigInt;
                        IdProducto.Value = productosCargar.IdProducto;
                        cmd2.Parameters.Add(IdProducto);

                        var IdVenta = new SqlParameter();
                        IdVenta.ParameterName = "idVenta";
                        IdVenta.SqlDbType = SqlDbType.BigInt;
                        IdVenta.Value = IdDeVenta;
                        cmd2.Parameters.Add(IdVenta);

                        cmd2.ExecuteNonQuery();

                        cmd.CommandText = ("SELECT Stock FROM Producto WHERE Id = @ProductoId");
                        cmd.Parameters.AddWithValue("@ProductoId", productosCargar.IdProducto);
                        var StockParaCambiar = Convert.ToInt32(cmd.ExecuteScalar());

                        int stockfinal = 0;
                        stockfinal = StockParaCambiar - productosCargar.Stock;

                        cmd.CommandText = ("UPDATE Producto SET Stock = @StockNuevo WHERE Id = @IdProductoCambiar");

                        var NuevoStock = new SqlParameter();
                        NuevoStock.ParameterName = "StockNuevo";
                        NuevoStock.SqlDbType = SqlDbType.BigInt;
                        NuevoStock.Value = stockfinal;
                        cmd.Parameters.Add(NuevoStock);

                        var IdProductoCambiar = new SqlParameter();
                        IdProductoCambiar.ParameterName = "IdProductoCambiar";
                        IdProductoCambiar.SqlDbType = SqlDbType.BigInt;
                        IdProductoCambiar.Value = productosCargar.IdProducto;
                        cmd.Parameters.Add(IdProductoCambiar);

                        cmd.ExecuteNonQuery();
                    }

                    conexion.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
