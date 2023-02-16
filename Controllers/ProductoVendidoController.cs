using ApiOwo.ADO.NET;
using ApiOwo.Models;
using ApiSistemaDeGestion.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoVendidoController : ControllerBase
    {
        [HttpGet("{id}")]
        public ProductoVenta traerProductoVendido(long id)
        {

            return ManejadorProductoVendido.traerProductoVendido(id);
        }

    }
}
