using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SomeController : ControllerBase
    {
        [HttpGet("sync")]
        public IActionResult GetSync()
        {
            Stopwatch sw = Stopwatch.StartNew();

            Thread.Sleep(1000);
            Console.WriteLine("Conectando a la BD.");

            Console.WriteLine("Haciendo algo intermedio.");

            Thread.Sleep(1000);
            Console.WriteLine("Enviando correo.");

            Console.WriteLine("Fin del programa.");

            sw.Stop();
            Console.WriteLine("Tiempo transcurrido: " + sw.Elapsed);

            return Ok();
        }
    }
}
