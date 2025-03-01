using Backend.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RandomController : ControllerBase
    {
        private IRandomService _randomSingleton;
        private IRandomService _randomScoped;
        private IRandomService _randomTransient;

        private IRandomService _random2Singleton;
        private IRandomService _random2Scoped;
        private IRandomService _random2Transient;

        //Constructor instanciando objetos
        public RandomController(
            [FromKeyedServices("randomSingleton")] IRandomService randomSingleton,
            [FromKeyedServices("randomScoped")] IRandomService randomScoped,
            [FromKeyedServices("randomTransient")] IRandomService randomTransient,
            [FromKeyedServices("randomSingleton")] IRandomService random2Singleton,
            [FromKeyedServices("randomScoped")] IRandomService random2Scoped,
            [FromKeyedServices("randomTransient")] IRandomService random2Transient
            )
        {
            _randomSingleton = randomSingleton;
            _randomScoped = randomScoped;
            _randomTransient = randomTransient;
            _random2Singleton = random2Singleton;
            _random2Scoped = random2Scoped;
            _random2Transient = random2Transient;
        }

        [HttpGet]
        public Dictionary<string, int> RandomData()
        {
            var result = new Dictionary<string, int>();

            // Registramos los valores
            result.Add("Singleton 1: ", _randomSingleton.Value);
            result.Add("Scoped 1: ", _randomScoped.Value);
            result.Add("Transient 1: ", _randomTransient.Value);
            result.Add("Singleton 2: ", _random2Singleton.Value);
            result.Add("Scoped 2: ", _random2Scoped.Value);
            result.Add("Transient 2: ", _random2Transient.Value);

            return result;
        }
    }
}
