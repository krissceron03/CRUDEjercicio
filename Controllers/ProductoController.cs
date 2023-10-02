using InicioProyectoClasesCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace InicioProyectoClasesCRUD.Controllers
{
    public class ProductoController : Controller
    {
        // GET: ProductoController
        public IActionResult Index()
        {
            return View(Util.Utils.listaProductos);
        }

        // GET: ProductoController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Producto producto)
        {
           
            int id = Util.Utils.listaProductos.Count()+1;
            producto.IdProducto = id;
            Util.Utils.listaProductos.Add(producto);
            return RedirectToAction("Index");
        }


        // POST: ProductoController/Create


        // GET: ProductoController/Edit/5
        public ActionResult Edit(int IdProducto)
        {
            Producto producto = Util.Utils.listaProductos.Find(x => x.IdProducto==IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        // POST: ProductoController/Edit/5
        

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int IdProducto)
        {
            Producto producto = Util.Utils.listaProductos.Find(x => x.IdProducto==IdProducto);
            if (producto != null) {
            Util.Utils.listaProductos.Remove(producto);
            }
            return RedirectToAction("Index");
        }

        // POST: ProductoController/Delete/5
       
    }
}
