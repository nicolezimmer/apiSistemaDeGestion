using ApiOwo.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOwo.ADO.NET
{
    internal static class ManejadorProductoVendido
    {
        public static List<ProductoVenta> traerProductoVendidoS(long id)
        {
            //Traer ProductosVendidos (recibe el id del usuario y devuelve una lista de productos vendidos por ese usuario)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from ProductoVendido where IdVenta = {id}", connection);
                List<ProductoVenta> ventas = new List<ProductoVenta>();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    // el reader.Read() devuelve true si existen mas filas debajo de la fila de la iteracion  
                    while (reader.Read())
                    {
                        ventas.Add(new ProductoVenta(reader.GetInt64(0), reader.GetInt64(2), reader.GetInt32(1), reader.GetInt64(3)));
                    }
                }
                return ventas;
            }
        }
        public static ProductoVenta traerProductoVendido(long id)
        {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from ProductoVendido where id = {id}", connection);
                ProductoVenta buscado = new ProductoVenta();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        buscado = new ProductoVenta(reader.GetInt64(0), reader.GetInt64(2), reader.GetInt32(1), reader.GetInt64(3));

                    }
                }
                return buscado;
            }
        }
        public static void eliminarDeProductoVendido(long id)
        {

                string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    using (SqlCommand comando = new SqlCommand($"DELETE FROM ProductoVendido where id = {id}", connection))
                    {
                        comando.ExecuteNonQuery();
                    }

                }

        }
        public static int InsertarProductoVendido(ProductoVenta productoVenta)
        {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                var queryInsert = $"insert into ProductoVendido(Stock, IdProducto, IdVenta) values (@Stock, @IdProducto, @IdVenta)";

                var Stock = new SqlParameter();

                Stock.ParameterName = "Stock";
                Stock.SqlDbType = SqlDbType.Int;
                Stock.Value = productoVenta.Stock;

                var IdProducto = new SqlParameter();

                IdProducto.ParameterName = "IdProducto";
                IdProducto.SqlDbType = SqlDbType.BigInt;
                IdProducto.Value = productoVenta.IdProducto;

                var IdVenta = new SqlParameter();

                IdVenta.ParameterName = "IdVenta";
                IdVenta.SqlDbType = SqlDbType.BigInt;
                IdVenta.Value = productoVenta.IdVenta;

                connection.Open();
                using (SqlCommand comando = new SqlCommand(queryInsert, connection))
                {
                    comando.Parameters.Add(Stock);
                    comando.Parameters.Add(IdProducto);
                    comando.Parameters.Add(IdVenta);
                    comando.ExecuteNonQuery();
                }
                connection.Close();
                return productoVenta.Stock;
            }
        }
    }
}
