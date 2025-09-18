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
    }
}
