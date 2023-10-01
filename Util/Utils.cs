using InicioProyectoClasesCRUD.Models;

namespace InicioProyectoClasesCRUD.Util
{
    public class Utils
    {
        public static List<Producto> listaProductos = new List<Producto>()
        {
            new Producto()
            {
                IdProducto = 1,
                Nombre= "Prodicto 1",
                Descripcion= "Descripcion 1",
                Cantidad = 1,
            },
            new Producto()
            {
                IdProducto = 2,
                Nombre= "Prodicto 2",
                Descripcion= "Descripcion 2",
                Cantidad = 2,
            },
            new Producto()
            {
                IdProducto = 3,
                Nombre= "Prodicto 3",
                Descripcion= "Descripcion 3",
                Cantidad = 3,
            },
            new Producto()
            {
                IdProducto = 4,
                Nombre= "Prodicto 4",
                Descripcion= "Descripcion 4",
                Cantidad = 4,
            },

        };
    }
}
