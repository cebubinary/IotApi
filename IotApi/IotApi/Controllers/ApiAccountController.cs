using IotApi.DataContext;
using IotApi.Models;
using IotApi.Repository;
using System.Linq;
using System.Web.Http;
using PersonContext = IotApi.DataContext.Person;

namespace IotApi.Controllers
{
    [RoutePrefix("api/ApiAccount")]
    public class ApiAccountController : ApiController
    {
  
        public ApiAccountController()
        { 
        }

        [Route("Login")]
        [HttpPost]
        public bool Login([FromBody] User user)
        {
            return new PersonRepository(new MoviesDBDataContext()).Login(user.Username, user.Password);
        }
       
        [Route("Register")]
        [HttpPost]
        public bool Register([FromBody] Account user)
        {           
            return new PersonRepository(new MoviesDBDataContext()).Resgister(user);
        }
        [Route("Delete")]
        [HttpPost]
        public bool Delete([FromBody] Account user)
        {
            return new PersonRepository(new MoviesDBDataContext()).DeleteRegisteredAccount(user);
        }
        [Route("Update")]
        [HttpPost]
        public bool Update([FromBody] Account user)
        {
            return new PersonRepository(new MoviesDBDataContext()).UpdateRegisteredAccount(user);
        }
    }
}
