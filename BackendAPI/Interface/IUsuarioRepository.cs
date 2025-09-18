using BackendAPI.DTO;

namespace BackendAPI.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDTO? BuscarUsuarioId(long id);
        List<UsuarioDTO>? ObtenerTodosLosUsuarios();
    }
}