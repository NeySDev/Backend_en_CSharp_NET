using Backend.Controllers;

namespace Backend.Services
{
    public class PeopleService : IPeopleService
    {
        public bool Validate(People people)
        {
            if (String.IsNullOrEmpty(people.Name))
            {
                return false;
            }

            return true;
        }
    }
}
