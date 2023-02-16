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
        [HttpGet("{usuario}/{contrasena}")]
        public Usuario Login(string usuario, string contrasena)
        {
            return ManejadorUsuario.inicioDeSesion(usuario, contrasena);
        }
        [HttpPut]
        public bool ModificarUsuario(Usuario usuario)
        {
            return ManejadorUsuario.modificarUsuario(usuario);
        }
        [HttpPost]
        public bool CrearUsuario(Usuario usuario)
        {
            return ManejadorUsuario.insertarUsuario(usuario);
        }



    }
}
