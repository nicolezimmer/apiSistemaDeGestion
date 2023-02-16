using ApiOwo.Models;
using ApiSistemaDeGestion.Repositorio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiOwo.ADO.NET
{
    internal static class ManejadorVenta
    {
        public static List<Venta> traerVentas(long id)
        {
            //Traer Ventas (recibe el id del usuario y devuelve un a lista de Ventas realizadas por ese usuario)
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand comando = new SqlCommand($"select * from Venta where IdUsuario = {id}", connection);
                List<Venta> ventas = new List<Venta>();
                connection.Open();
                SqlDataReader reader = comando.ExecuteReader();
                if (reader.HasRows)
                {
                    // el reader.Read() devuelve true si existen mas filas debajo de la fila de la iteracion  
                    while (reader.Read())
                    {
                        ventas.Add(new Venta(reader.GetInt64(0), reader.GetString(1), reader.GetInt64(2)));
                    }
                }
                return ventas;
            }
        }
        public static long InsertarVenta(Venta venta) {
            string connectionString = "Data Source=PCNICOLAS\\SQLEXPRESS;Initial Catalog=SistemaGestion;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string c = "insert into Venta (IdUsuario) values (@IdUsuario); select @@IDENTITY";
                var IdUsuario = new SqlParameter();

                IdUsuario.ParameterName = "IdUsuario";
                IdUsuario.SqlDbType = SqlDbType.BigInt;
                IdUsuario.Value = venta.IdUsuario;
                connection.Open();
                long IdVenta = 0;
                using (SqlCommand comando = new SqlCommand(c, connection))
                {
                    comando.Parameters.Add(IdUsuario);
                    IdVenta=Convert.ToInt64(comando.ExecuteScalar()); 
                }
                connection.Close();
                return IdVenta;
            }
        }

        public static bool CargarVenta(long id, List<Producto> productosVendidos) {
            try
            {
                long IdVenta = 0;
                foreach (Producto producto in productosVendidos)
                {
                    Venta venta = new Venta(0, "", id);
                    IdVenta = InsertarVenta(venta);
                    ProductoVenta productoVenta = new ProductoVenta(0, producto.Id, ManejadorProducto.UpdateStockProducto(producto.Id, 1), IdVenta);
                    ManejadorProductoVendido.InsertarProductoVendido(productoVenta);

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
