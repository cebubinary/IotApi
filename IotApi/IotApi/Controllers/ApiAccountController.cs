using SharedContracts.SharedObjects;
using System.Web.Http;
using AccountService = Iot.Services.IoT.AccountService;
using System.Collections.Generic;

namespace IotApi.Controllers
{
    [RoutePrefix("api/ApiAccount")]
    public class ApiAccountController : ApiController
    {
        AccountService accountService;
       // AccountService accountService;
  
        public ApiAccountController()
        {
            accountService = new AccountService();
        }

        [Route("Login")]
        [HttpPost]
        public bool Login([FromBody] Account user)
        {
            return accountService.Login(user.Username,user.Password);
        }

        [Route("Register")]
        [HttpPost]
        public bool Register([FromBody] Account user)
        {
            return accountService.AddNewAccount(user);
        }
        [Route("Delete")]
        [HttpPost]
        public Person Delete([FromBody] Account user)
        {
            return accountService.Delete(user);
        }
        [Route("Update")]
        [HttpPost]
        public Person Update([FromBody] Account user)
        {
            return accountService.Update(user);
        }
        [Route("GetAll")]
        [HttpGet]
        public List<Person> GetAll()
        {

            return accountService.GetAll();
        }
    }
}
