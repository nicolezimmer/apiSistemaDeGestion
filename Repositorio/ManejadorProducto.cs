using ApiOwo.Models;
using Microsoft.Extensions.Hosting;
using System.Data;
using System.Data.SqlClient;

namespace ApiSistemaDeGestion.Repositorio
{
    public class ManejadorProducto
    {
        public static List<Producto> traerProductos(long id)
        {
            //Traer Productos (recibe un id de usuario y, devuelve una lista con todos los productos cargado por ese usuario)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Producto where IdUsuario = {id}", connection);
                List<Producto> productos = new List<Producto>();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        productos.Add(new Producto(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5)));


                    }
                }
                return productos;
            }
        }
        public static Producto traerProducto(long id)
        {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Producto where id = {id}", connection);
                Producto buscado = new Producto();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        buscado = new Producto(reader.GetInt64(0), reader.GetString(1), reader.GetDecimal(2), reader.GetDecimal(3), reader.GetInt32(4), reader.GetInt64(5));

                    }
                }
                return buscado;
            }
        }
        public static void insertarProducto(Producto producto)
        {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryInsert = $"insert into Producto(Descripciones, Costo, PrecioVenta, Stock, IdUsuario) values (@Descripciones, @Costo, @PrecioVenta, @Stock, @IdUsuario)";

                var descripcion = new SqlParameter();

                descripcion.ParameterName = "Descripciones";
                descripcion.SqlDbType = SqlDbType.VarChar;
                descripcion.Value = producto.Descripcion;

                var costo = new SqlParameter();

                costo.ParameterName = "Costo";
                costo.SqlDbType = SqlDbType.Decimal;
                costo.Value = producto.Costo;

                var PrecioVenta = new SqlParameter();

                PrecioVenta.ParameterName = "PrecioVenta";
                PrecioVenta.SqlDbType = SqlDbType.Decimal;
                PrecioVenta.Value = producto.PrecioVenta;

                var Stock = new SqlParameter();

                Stock.ParameterName = "Stock";
                Stock.SqlDbType = SqlDbType.Int;
                Stock.Value = producto.Stock;

                var IdUsuario = new SqlParameter();

                IdUsuario.ParameterName = "IdUsuario";
                IdUsuario.SqlDbType = SqlDbType.BigInt;
                IdUsuario.Value = producto.IdUsuario;

                connection.Open();
                using (SqlCommand comando = new SqlCommand(queryInsert, connection))
                {
                    comando.Parameters.Add(descripcion);
                    comando.Parameters.Add(costo);
                    comando.Parameters.Add(PrecioVenta);
                    comando.Parameters.Add(Stock);
                    comando.Parameters.Add(IdUsuario);
                    comando.ExecuteNonQuery();
                }
                connection.Close();

            }
        }
        public static void modificarProducto(Producto producto)
        {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryInsert = $"UPDATE Producto SET Descripciones=@Descripciones, Costo=@Costo, PrecioVenta=@PrecioVenta, Stock=@Stock, IdUsuario=@IdUsuario WHERE Id=@Id\r\n";

                var Id = new SqlParameter();

                Id.ParameterName = "Id";
                Id.SqlDbType = SqlDbType.BigInt;
                Id.Value = producto.Id;

                var descripcion = new SqlParameter();

                descripcion.ParameterName = "Descripciones";
                descripcion.SqlDbType = SqlDbType.VarChar;
                descripcion.Value = producto.Descripcion;

                var costo = new SqlParameter();

                costo.ParameterName = "Costo";
                costo.SqlDbType = SqlDbType.Decimal;
                costo.Value = producto.Costo;

                var PrecioVenta = new SqlParameter();

                PrecioVenta.ParameterName = "PrecioVenta";
                PrecioVenta.SqlDbType = SqlDbType.Decimal;
                PrecioVenta.Value = producto.PrecioVenta;

                var Stock = new SqlParameter();

                Stock.ParameterName = "Stock";
                Stock.SqlDbType = SqlDbType.Int;
                Stock.Value = producto.Stock;

                var IdUsuario = new SqlParameter();

                IdUsuario.ParameterName = "IdUsuario";
                IdUsuario.SqlDbType = SqlDbType.BigInt;
                IdUsuario.Value = producto.IdUsuario;

                connection.Open();
                using (SqlCommand comando = new SqlCommand(queryInsert, connection))
                {
                    comando.Parameters.Add(descripcion);
                    comando.Parameters.Add(costo);
                    comando.Parameters.Add(PrecioVenta);
                    comando.Parameters.Add(Stock);
                    comando.Parameters.Add(IdUsuario);
                    comando.Parameters.Add(Id);

                    comando.ExecuteNonQuery();
                }
                connection.Close();

            }

        }
        public static void eliminarProducto(long id)
        {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                using (SqlCommand comando = new SqlCommand($"DELETE FROM Producto where id = {id}", connection))
                {
                    comando.ExecuteNonQuery();
                }

            }
        }
    }
}
