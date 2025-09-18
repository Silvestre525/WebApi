using BackendAPI.DTO;
using BackendAPI.EF;
using BackendAPI.Interface;

namespace BackendAPI.Repositories
{
    public class UsuarioRepository(MyDbContext _context) : IUsuarioRepository
    {
        //Se pueda buscar Usuario por Id
        public UsuarioDTO? BuscarUsuarioId(long id)
        {
            var usuarioPorId = (
                 from u in _context.Usuarios
                 where u.UsuarioId == id
                 select new UsuarioDTO
                 {
                     nombre = u.nombre,
                 }
                 ).FirstOrDefault();

            return usuarioPorId;
        }

        //Obtener todos los usuarios

        public List<UsuarioDTO>? ObtenerTodosLosUsuarios()
        {

            List<UsuarioDTO> retorno = new List<UsuarioDTO>();

            var query = _context.Usuarios.Where(u => !u.isDeleted).ToList();

            foreach (Models.Usuario usuario in query)
            {

                retorno.Add(new UsuarioDTO
                {
                    nombre = usuario.nombre

                });

            }


            return retorno;

        }

        ///Crear un repositorio de Usuario donde:

        //Se pueda buscar Usuario por Nombre
        //Se pueda buscar Usuario si el Apellido comienza con....
        //No se pueden mostrar los usuarios eliminados en ningún caso.
        //No se puede exponer ningún objeto del EF
    }
}
