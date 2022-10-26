using ConsignaFinal.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace ConsignaFinal.Repository
{
    public class Ado_UsuarioModificacion
    {
        internal static List<Usuario> CrearUsuario(Usuario user)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listUsuarios = new List<Usuario>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "INSERT INTO Usuario(Nombre,Apellido,NombreUsuario,Contraseña,Mail) VALUES(@NombreDeUsuario, @Apellido, @NombreUsuario,@contrasena,@Mail)";

                    var Nombre = new SqlParameter();
                    Nombre.ParameterName = "NombreDeUsuario";
                    Nombre.SqlDbType = SqlDbType.VarChar;
                    Nombre.Value = user.Nombre;
                    cmd.Parameters.Add(Nombre);

                    var Apellido = new SqlParameter();
                    Apellido.ParameterName = "Apellido";
                    Apellido.SqlDbType = SqlDbType.VarChar;
                    Apellido.Value = user.Apellido;
                    cmd.Parameters.Add(Apellido);

                    var NombreUsuario = new SqlParameter();
                    NombreUsuario.ParameterName = "NombreUsuario";
                    NombreUsuario.SqlDbType = SqlDbType.VarChar;
                    NombreUsuario.Value = user.NombreUsuario;
                    cmd.Parameters.Add(NombreUsuario);

                    var Contrasena = new SqlParameter();
                    Contrasena.ParameterName = "contrasena";
                    Contrasena.SqlDbType = SqlDbType.VarChar;
                    Contrasena.Value = user.Contrasena;
                    cmd.Parameters.Add(Contrasena);

                    var Mail = new SqlParameter();
                    Mail.ParameterName = "Mail";
                    Mail.SqlDbType = SqlDbType.VarChar;
                    Mail.Value = user.Mail;
                    cmd.Parameters.Add(Mail);

                    cmd.ExecuteNonQuery();

                    conexion.Close();

                    return listUsuarios;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> EditarUsuario(Usuario user)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listUsuarios = new List<Usuario>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "UPDATE Usuario SET Nombre = @NombreDeUsuario, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @contrasena, Mail = @Mail WHERE Id = @IdUser ";

                    var Nombre = new SqlParameter();
                    Nombre.ParameterName = "NombreDeUsuario";
                    Nombre.SqlDbType = SqlDbType.VarChar;
                    Nombre.Value = user.Nombre;
                    cmd.Parameters.Add(Nombre);

                    var Apellido = new SqlParameter();
                    Apellido.ParameterName = "Apellido";
                    Apellido.SqlDbType = SqlDbType.VarChar;
                    Apellido.Value = user.Apellido;
                    cmd.Parameters.Add(Apellido);

                    var NombreUsuario = new SqlParameter();
                    NombreUsuario.ParameterName = "NombreUsuario";
                    NombreUsuario.SqlDbType = SqlDbType.VarChar;
                    NombreUsuario.Value = user.NombreUsuario;
                    cmd.Parameters.Add(NombreUsuario);

                    var Contrasena = new SqlParameter();
                    Contrasena.ParameterName = "contrasena";
                    Contrasena.SqlDbType = SqlDbType.VarChar;
                    Contrasena.Value = user.Contrasena;
                    cmd.Parameters.Add(Contrasena);

                    var Mail = new SqlParameter();
                    Mail.ParameterName = "Mail";
                    Mail.SqlDbType = SqlDbType.VarChar;
                    Mail.Value = user.Mail;
                    cmd.Parameters.Add(Mail);

                    var idUser = new SqlParameter();
                    idUser.ParameterName = "IdUser";
                    idUser.SqlDbType = SqlDbType.VarChar;
                    idUser.Value = user.Id;
                    cmd.Parameters.Add(idUser);

                    cmd.ExecuteNonQuery();

                    conexion.Close();

                    return listUsuarios;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> EliminarUsuario(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var listUsuarios = new List<Usuario>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "DELETE FROM Usuario Where Id = @IdUser";

                    Convert.ToInt32(id);

                    var IdUser = new SqlParameter();
                    IdUser.ParameterName = "IdUser";
                    IdUser.SqlDbType = SqlDbType.VarChar;
                    IdUser.Value = id;
                    cmd.Parameters.Add(IdUser);

                    cmd.ExecuteNonQuery();

                    conexion.Close();

                    return listUsuarios;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static List<Usuario> Login(Login log)
        {
            var ListLoginUser = new List<Usuario>();

            if (log.Contrasena != "" || log.Usuario != "")
            {
                if (log.Contrasena != "string" || log.Usuario != "string")
                {
                    try
                    {
                        var conn = new Conexion();

                        using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                        {
                            conexion.Open();
                            SqlCommand cmd = conexion.CreateCommand();
                            cmd.CommandText = "SELECT * FROM Usuario WHERE NombreUsuario = @NombreUser AND Contraseña = @Contrasena";

                            var NombreUser = new SqlParameter();
                            NombreUser.ParameterName = "NombreUser";
                            NombreUser.SqlDbType = SqlDbType.VarChar;
                            NombreUser.Value = log.Usuario;
                            cmd.Parameters.Add(NombreUser);

                            var Contrasena = new SqlParameter();
                            Contrasena.ParameterName = "Contrasena";
                            Contrasena.SqlDbType = SqlDbType.VarChar;
                            Contrasena.Value = log.Contrasena;
                            cmd.Parameters.Add(Contrasena);

                            var reader = cmd.ExecuteReader();
                            while (reader.Read())
                            {
                                var userLogin = new Usuario();

                                userLogin.Id = Convert.ToInt32(reader.GetValue(0));
                                userLogin.Nombre = reader.GetValue(1).ToString();
                                userLogin.Apellido = reader.GetValue(2).ToString();
                                userLogin.NombreUsuario = reader.GetValue(3).ToString();
                                userLogin.Contrasena = reader.GetValue(4).ToString();
                                userLogin.Mail = reader.GetValue(5).ToString();

                                ListLoginUser.Add(userLogin);
                            }
                            reader.Close();
                            conexion.Close();

                        }

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                }
            }
            return ListLoginUser;
        }

        internal static List<Usuario> Perfil(int id)
        {
            try
            {
                var conn = new Conexion();

                using (var conexion = new SqlConnection(conn.getCadenaSQL()))
                {
                    var ListUsuario = new List<Usuario>();
                    conexion.Open();
                    SqlCommand cmd = conexion.CreateCommand();
                    cmd.CommandText = "SELECT * FROM Usuario WHERE Id = @IdUsuario";

                    Convert.ToInt32(id);

                    var IdUsuario = new SqlParameter();
                    IdUsuario.ParameterName = "IdUsuario";
                    IdUsuario.SqlDbType = SqlDbType.VarChar;
                    IdUsuario.Value = id;
                    cmd.Parameters.Add(IdUsuario);


                    var reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var Usuario = new Usuario();

                        Usuario.Id = Convert.ToInt32(reader.GetValue(0));
                        Usuario.Nombre = reader.GetValue(1).ToString();
                        Usuario.Apellido = reader.GetValue(2).ToString();
                        Usuario.NombreUsuario = reader.GetValue(3).ToString();
                        Usuario.Contrasena = reader.GetValue(4).ToString();
                        Usuario.Mail = reader.GetValue(5).ToString();

                        ListUsuario.Add(Usuario);
                    }
                    reader.Close();
                    conexion.Close();

                    return ListUsuario;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
