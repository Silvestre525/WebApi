using System.ComponentModel.DataAnnotations;

namespace BackendAPI.Models
{
    public class Producto: BaseField
    {
        [Key]
        public int ProductoId { get; set; }
        public string NombreProducto { get; set; }
    }
}
