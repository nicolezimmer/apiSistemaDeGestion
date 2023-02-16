using ApiOwo.ADO.NET;
using ApiOwo.Models;
using ApiSistemaDeGestion.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        [HttpPost("{idUsuario}")]
        public bool CargarVenta([FromBody] List<Producto> productosVendidos, long idUsuario)
        {
            return ManejadorVenta.CargarVenta(idUsuario, productosVendidos);

        }
    }
}
