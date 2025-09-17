using System.ComponentModel.DataAnnotations;
using System.Security;

namespace BackendAPI.Models
{
    public class Usuario: BaseField
    {
        [Key]
        public long UsuarioId { get; set; }

        [MaxLength(250)]
        public String nombre { get; set; }

        public String apellido { get; set; }


    }
}
