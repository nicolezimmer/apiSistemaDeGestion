using ApiOwo.Models;
using System.Data.SqlClient;

namespace ApiSistemaDeGestion.Repositorio
{
    public class ManejadorUsuario
    {
        public static Usuario inicioDeSesion(string usuario, string contraseña)
        {

            //Inicio de sesión (recibe un usuario y contraseña y devuelve un objeto Usuario)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Usuario where NombreUsuario= '{usuario.Trim()}' and Contraseña = '{contraseña}'", connection);
                Usuario buscado = new Usuario();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        buscado = new Usuario(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));

                    }
                }
                return buscado;
            }
        }
        public static Usuario traerUsuario(long id)
        {
            //Traer Usuario (recibe un int)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Usuario where id = {id}", connection);
                Usuario buscado = new Usuario();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        buscado = new Usuario(reader.GetInt64(0), reader.GetString(1), reader.GetString(2), reader.GetString(3), reader.GetString(4), reader.GetString(5));

                    }
                }
                return buscado;
            }
        }
        public static bool insertarUsuario(Usuario usuario)
        {
            try
            {
                string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand comando = new SqlCommand($"INSERT INTO Usuario (Nombre, Apellido, NombreUsuario, Contraseña, Mail) VALUES ('{usuario.Nombre}', '{usuario.Apellido}', '{usuario.NombreUsuario}', '{usuario.Contraseña}', '{usuario.Mail}')\r\n", connection))
                    {
                        comando.ExecuteNonQuery();
                    }
                    connection.Close();

                }

                    return true;

            }
            catch (Exception ex)
            {
                return false;
            }


        }
        public static bool modificarUsuario(Usuario usuario)
        {
            try
            {
                string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand comando = new SqlCommand($"UPDATE Usuario SET Nombre = '{usuario.Nombre}',Apellido = '{usuario.Apellido}',NombreUsuario = '{usuario.NombreUsuario}',Contraseña = '{usuario.Contraseña}',Mail = '{usuario.Mail}' WHERE Id={usuario.Id}\r\n", connection))
                    {
                        comando.ExecuteNonQuery();
                    }
                    connection.Close();

                }

                    return true;

            }
            catch(Exception ex)
            {
                return false;   
            }

        }
    }
}

