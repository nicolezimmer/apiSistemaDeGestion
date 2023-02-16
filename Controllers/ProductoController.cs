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
        public bool CrearProducto(Producto producto)
        {
            return ManejadorProducto.insertarProducto(producto);

        }

        [HttpPut]
        public bool ModificarProducto(Producto producto)
        {
            return ManejadorProducto.modificarProducto(producto);

        }

        [HttpDelete("{id}")]
        public bool EliminarProducto(long id)
        {
            return ManejadorProducto.eliminarProducto(id);
        }
    }
}
