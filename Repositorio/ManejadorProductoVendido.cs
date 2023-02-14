using ApiOwo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOwo.ADO.NET
{
    internal static class ManejadorProductoVendido
    {
        public static List<ProductoVenta> traerProductoVendido(long id)
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
    }
}
