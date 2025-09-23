using BackendAPI.DTO;

namespace BackendAPI.Interface
{
    public interface IUsuarioRepository
    {
        UsuarioDTO? BuscarUsuarioId(long id);
        List<UsuarioDTO>? ObtenerTodosLosUsuarios();

        List<UsuarioDTO>? BuscarUsuariosPorNombre(string nombre);

        UsuarioDTO CrearUsuario(UsuarioCreateDTO nuevoUsuario);
    }
}