using BackendAPI.DTO;
using BackendAPI.EF;

namespace BackendAPI.Repositories
{
    public class UsuarioRepository(MyDbContext _context)
    {
        //Se pueda buscar Usuario por Id
        public UsuarioDTO BuscarUsuarioIdE(long id)
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


        ///Crear un repositorio de Usuario donde:
     
        //Se pueda buscar Usuario por Nombre
        //Se pueda buscar Usuario si el Apellido comienza con....
        //No se pueden mostrar los usuarios eliminados en ningún caso.
        //No se puede exponer ningún objeto del EF
    }
}
