using ConsignaFinal.Models;
using static ConsignaFinal.Controllers.UsuarioController;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsignaFinal.Repository
{
    public class Ado_Usuario
    {       
        public static List<Usuario> BuscarPorId(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listUsuarios = new List<Usuario>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Usuario WHERE id = @idUser";

                    Convert.ToInt32(id);

                    var IdUserParam = new SqlParameter("idUser", System.Data.SqlDbType.BigInt);
                    IdUserParam.Value = id;

                    cmd.Parameters.Add(IdUserParam);

                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var usuario = new Usuario();

                        usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        usuario.Nombre = reader.GetValue(1).ToString();
                        usuario.Apellido = reader.GetValue(2).ToString();
                        usuario.NombreUsuario = reader.GetValue(3).ToString();
                        usuario.Mail = reader.GetValue(5).ToString();

                        listUsuarios.Add(usuario);
                    }
                    reader.Close();
                    conexion.Close();

                    return listUsuarios;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }      
    }
}
