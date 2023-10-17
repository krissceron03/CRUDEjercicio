using InicioProyectoClasesCRUD.Data;
using InicioProyectoClasesCRUD.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace InicioProyectoClasesCRUD.Controllers
{
    public class ProductoController : Controller
    {
        //DECLARAR EL CLIENTE UNICO HTTP
        private readonly ClientHttp _httpClientFactory;
        //el constructor llama a la cración del cliente
        public ProductoController(ClientHttp httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        // GET: ProductoController
        public async Task<IActionResult> Index()
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.GetAsync("api/Producto");
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // Imprime el JSON en la consola
                    Console.WriteLine(data);
                    var productoslistado = JsonSerializer.Deserialize<IEnumerable<Producto>>(data);

                    return View(productoslistado);
                }
                else
                {
                    return View("Exception", new { message = "Error retrieving data" });
                }
            }

                //return View(Util.Utils.listaProductos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int idProducto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.GetAsync("api/Producto/"+idProducto);
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    // Imprime el JSON en la consola
                    Console.WriteLine(data);
                    var productoEcontrado = JsonSerializer.Deserialize<Producto>(data);

                    return View(productoEcontrado);
                }
                else
                {
                    return View("Exception", new { message = "Error retrieving data" });
                }
            }

            /*Producto producto = Util.Utils.listaProductos.Find(x => x.idProducto==idProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");*/
        }

        // GET: ProductoController/Create
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                // Serializar el objeto Producto a formato JSON
                var jsonProducto = JsonSerializer.Serialize(producto);

                // Crear el contenido de la solicitud con el JSON
                var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST
                var response = await httpClient.PostAsync("api/Producto", content);
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Exception", new { message = "Error retrieving data" });
                }
            }


            /*int id = Util.Utils.listaProductos.Count()+1;
            producto.idProducto = id;
            Util.Utils.listaProductos.Add(producto);
            return RedirectToAction("Index");*/
        }


        // POST: ProductoController/Create


        // GET: ProductoController/Edit/5
        public ActionResult Edit(int IdProducto)
        {
            Producto producto = Util.Utils.listaProductos.Find(x => x.idProducto==IdProducto);
            if (producto != null)
            {
                return View(producto);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(int IdProducto,string Nombre, string Descripcion, int Cantidad)
        {
            Producto producto = Util.Utils.listaProductos.Find(x => x.idProducto==IdProducto);
            if (producto != null)
            {
                producto.nombre = Nombre;
                producto.cantidad = Cantidad;
                producto.descripcion = Descripcion;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        // POST: ProductoController/Edit/5


        // GET: ProductoController/Delete/5
        public ActionResult Delete(int IdProducto)
        {
            Producto producto = Util.Utils.listaProductos.Find(x => x.idProducto==IdProducto);
            if (producto != null) {
            Util.Utils.listaProductos.Remove(producto);
            }
            return RedirectToAction("Index");
        }

        // POST: ProductoController/Delete/5
       
    }
}
