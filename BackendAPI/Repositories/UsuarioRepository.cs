using BackendAPI.DTO;
using BackendAPI.EF;
using BackendAPI.Interface;
using BackendAPI.Models;

namespace BackendAPI.Repositories
{
    public class UsuarioRepository(MyDbContext _context) : IUsuarioRepository
    {

        public UsuarioDTO CrearUsuario(UsuarioCreateDTO nuevoUsuario)
        {
            var usuario = new Usuario
            {
                nombre = nuevoUsuario.nombre,
                apellido = nuevoUsuario.apellido,
                isDeleted = false,
                createdBy = "system",            
                createdOn = DateTime.UtcNow      
            };

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();

            // Retornamos un DTO para no exponer directamente el modelo
            return new UsuarioDTO
            {
                nombre = usuario.nombre
            };
        } 


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

        //Se pueda buscar Usuario por Nombre
        public List<UsuarioDTO>? BuscarUsuariosPorNombre(string nombre)
        {
            return _context.Usuarios
                .Where(u => !u.isDeleted && u.nombre == nombre) // Filtra solo los que se llaman "nombre"
                .Select(u => new UsuarioDTO
                {
                    nombre = u.nombre
                }).ToList();
        }

        //Se pueda buscar Usuario si el Apellido comienza con....
        //No se pueden mostrar los usuarios eliminados en ningún caso.
        //No se puede exponer ningún objeto del EF
    }
}
