using ConsignaFinal.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsignaFinal.Repository
{
    public class Ado_ProductoModificar
    {
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
    }
}
