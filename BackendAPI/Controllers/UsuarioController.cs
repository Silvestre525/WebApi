using BackendAPI.DTO;
using BackendAPI.Interface;
using Microsoft.AspNetCore.Mvc;

namespace BackendAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController(IUsuarioRepository _usuarioRepository) : ControllerBase
    {


        [HttpGet(Name = "ObtenerTodosLosUsuarios")]
        public List<UsuarioDTO>? Get()
        {
            var queryRepository = _usuarioRepository.ObtenerTodosLosUsuarios();
            return queryRepository;
        }

        [HttpGet("BuscarId/{id}", Name = "BuscarId")]
        public UsuarioDTO?GetById(long id)
        {
            return _usuarioRepository.BuscarUsuarioId(id);
        }

        [HttpGet("BuscarNombre/{nombre}", Name = "BuscarUsuariosPorNombre")]
        public List<UsuarioDTO>? GetByName(string nombre)
        {
            return _usuarioRepository.BuscarUsuariosPorNombre(nombre);
        }

        [HttpPost(Name = "CrearUsuario")]
        public ActionResult<UsuarioDTO> CrearUsuario([FromBody] UsuarioCreateDTO usuarioNuevo)
        {
            if (usuarioNuevo == null)
            {
                return BadRequest("El usuario no puede ser nulo.");
            }

            var creado = _usuarioRepository.CrearUsuario(usuarioNuevo);

            return CreatedAtRoute("BuscarUsuariosPorNombre", new { nombre = creado.nombre }, creado);
        }

        [HttpGet("buscar-por-edad/{edad}", Name = "BuscarUsuariosPorEdad")]
        public List<UsuarioDTO>? GetByEdad(int edad)
        {
            return _usuarioRepository.BuscarUsuariosPorEdad(edad);
        }

    }
}
