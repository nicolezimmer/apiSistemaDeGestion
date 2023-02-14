using ApiOwo.ADO.NET;
using ApiOwo.Models;
using ApiSistemaDeGestion.Repositorio;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiSistemaDeGestion.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {

        [HttpGet("{id}")]
        public Usuario traerUsuario(long id)
        {

            return ManejadorUsuario.traerUsuario(id);
        }

        [HttpPut]
        public void ModificarUsuario(Usuario usuario)
        {
            ManejadorUsuario.modificarUsuario(usuario);

        }
        


    }
}
