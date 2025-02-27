using Backend.Services;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private IPeopleService _peopleService;

        public PeopleController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet(Name = "All")]
        public List<People> GetPeoples() => Repository.People;

        [HttpGet("{id}")]
        public ActionResult<People> GetPerson(int id)
        {
            var personFind = Repository.People.FirstOrDefault(p => p.Id == id);

            if(personFind == null)
                return NotFound();

            return Ok(personFind);
        }

        [HttpGet("search/{search}")]
        public List<People> GetPerson(string search)
        {
            var personFind = Repository.People.Where(p => p.Name.ToUpper().Contains(search.ToUpper())).ToList();
            return personFind;
        }

        [HttpPost]
        public IActionResult Add(People people)
        {
            if (!_peopleService.Validate(people))
                return BadRequest();

            Repository.People.Add(people);

            return NoContent();
        }
    }

    #region DATA
    public static class Repository
    {
        // Almacenamiento en memoria de personas
        public static List<People> People = new List<People>()
        {
            new People()
            {
                Id = 1,
                Name = "Nelson",
                Age = 26
            },
            new People()
            {
                Id = 2,
                Name = "Alexa",
                Age = 30
            },
            new People()
            {
                Id = 3,
                Name = "Viqui",
                Age = 33
            },
        };
    }
    #endregion

    #region MODELS
    public class People
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }
    #endregion
}
