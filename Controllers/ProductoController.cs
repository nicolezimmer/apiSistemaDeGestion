using ApiOwo.Models;
using ApiSistemaDeGestion.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        [HttpGet("{id}")]
        public Producto traerProducto(long id)
        {

            return ManejadorProducto.traerProducto(id);
        }
        [HttpPost]
        public void CrearProducto(Producto producto)
        {
            ManejadorProducto.insertarProducto(producto);

        }

        [HttpPut]
        public void ModificarProducto(Producto producto)
        {
            ManejadorProducto.modificarProducto(producto);

        }

        [HttpDelete("{id}")]
        public void EliminarProducto(long id)
        {
            ManejadorProducto.eliminarProducto(id);
        }
    }
}
