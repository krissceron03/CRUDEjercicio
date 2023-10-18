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
                var response = await httpClient.GetAsync("api/Producto");//verbo get porque retorna todo
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
                    ViewBag.ErrorMessage = "Asegurate de tener conexión con la API";
                    return View("ErrorView"); ;
                }
            }

                //return View(Util.Utils.listaProductos);
        }

        // GET: ProductoController/Details/5
        public async Task<IActionResult> Details(int idProducto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.GetAsync("api/Producto/"+idProducto);//se usa el verbo get porque la solicitus es tipo get
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
                    ViewBag.ErrorMessage = "No se pueden mostrar los detalles por el momento";
                    return View("ErrorView");
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
                var response = await httpClient.PostAsync("api/Producto", content);//usa el verbo post porque la solicitud es post
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Debe llenar los campos";
                    return View("ErrorView");
                }
            }


            /*int id = Util.Utils.listaProductos.Count()+1;
            producto.idProducto = id;
            Util.Utils.listaProductos.Add(producto);
            return RedirectToAction("Index");*/
        }


        // POST: ProductoController/Create


        // GET: ProductoController/Edit/5
        public ActionResult Edit(int IdProducto)//los métodos que no son de tipo hhttp post sireven para ser usados en partes como los botones
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Producto producto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                // Serializar el objeto Producto a formato JSON
                var jsonProducto = JsonSerializer.Serialize(producto);

                // Crear el contenido de la solicitud con el JSON
                var content = new StringContent(jsonProducto, Encoding.UTF8, "application/json");

                // Realiza la solicitud POST
                var response = await httpClient.PutAsync("api/Producto/"+producto.idProducto, content);//usa el verbo put porque la solicitud es post
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.ErrorMessage = "Debe llenar los campos";
                    return View("ErrorView");
                }
            }


            /*Producto producto = Util.Utils.listaProductos.Find(x => x.idProducto==IdProducto);
            if (producto != null)
            {
                producto.nombre = Nombre;
                producto.cantidad = Cantidad;
                producto.descripcion = Descripcion;
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");*/
        }

        // POST: ProductoController/Edit/5


        // GET: ProductoController/Delete/5
        public async Task<IActionResult> Delete(int idProducto)
        {
            using (var httpClient = _httpClientFactory.CreateHttpClient())
            {
                var response = await httpClient.DeleteAsync($"api/Producto/"+idProducto);//Se usa el verbo delete para saber que se hace un request de ese tipo
                
                // Procesa la respuesta correcta
                if (response.IsSuccessStatusCode)
                {
                   // Imprime el JSON en la consola
                    Console.WriteLine(response);
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Exception", new { message = "Error retrieving data" });
                }
                /*Producto producto = Util.Utils.listaProductos.Find(x => x.idProducto==IdProducto);
                if (producto != null) {
                Util.Utils.listaProductos.Remove(producto);
                }
                return RedirectToAction("Index");*/
            }

            // POST: ProductoController/Delete/5
        }
    }
}
