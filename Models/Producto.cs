using System.ComponentModel.DataAnnotations;

namespace InicioProyectoClasesCRUD.Models
{
    public class Producto
    {
        public int IdProducto { get; set; }
        [Required]
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [Required]
        public int Cantidad { get; set; }
    }
}
