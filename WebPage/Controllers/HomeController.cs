using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Diagnostics;
using WebPage.Models;

namespace WebPage.Controllers
{
    public class HomeController : Controller
    {
        String api = "https://localhost:7221/Car/";

        private static List<CarModel> cars;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            Thread.Sleep(1000);
            cars = new List<CarModel>();
            using (var cliente = new HttpClient())
            {
                cliente.BaseAddress = new Uri(api);
                HttpResponseMessage mensaje = await cliente.GetAsync("GetAll");
                if (mensaje.IsSuccessStatusCode)
                {
                    string respuesta = await mensaje.Content.ReadAsStringAsync();
                    cars = JsonConvert.DeserializeObject<List<CarModel>>(respuesta);
                }
            }
            Random randy = new Random();

            int rvalue = randy.Next(cars.Count);
            ViewBag.Correct = false;
            return View("Index", cars[rvalue]);
        }

        [HttpPost]
        public async Task<IActionResult> Guess(CarModel reg)
        {
            var value = cars.FirstOrDefault(X=> X.Id == reg.Id);
            if (reg.Price >= (value.Price - 5000) && reg.Price <= (value.Price + 5000))
            {
                ViewBag.Correct = true;
         
            }
            else {
                ViewBag.Correct = false;
            }

            return View("Index",value);
            //string mensaje = "";
            //using (var cliente = new HttpClient())
            //{
            //    reg.fsolicitud = DateTime.Now;
            //    reg.desact = "-";
            //    cliente.BaseAddress = new Uri(api);
            //    //convierto a reg en un cadena json de formato utf-8 y media: applicacion/json
            //    StringContent contenido = new StringContent(
            //    JsonConvert.SerializeObject(reg), System.Text.Encoding.UTF8, "application/json");
            //    //ejecutar el Put
            //    HttpResponseMessage respuesta = await cliente.PostAsync("registrar", contenido);
            //    if (respuesta.IsSuccessStatusCode)
            //    {
            //        mensaje = await respuesta.Content.ReadAsStringAsync();
            //    }
            //}
            ////al finalizar refrescar la pagina
            //ViewBag.mensaje = mensaje;
            //ViewBag.solicitudes = await solicitudes();
            //ViewBag.actividades = new SelectList(await actividades(), "idact", "desact");
            //ViewBag.titulo = "Agregar";
            ////envio un nuevo Seller, GET
            //return View("Index", await Task.Run(() => new Solicitud()));

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}