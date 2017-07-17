using System.Web.Http;

namespace IotApi.Controllers
{
    [RoutePrefix("api/MyApi")]
    [BasicAuth]
    public class MyApiController : ApiController
    {



        public MyApiController()
        {

        }

        //[HttpPost]
        //[Route("PostTestTickle/{paramId}/{param2}/Something")]
        //public bool PostTestTickle([FromUri] long paramId,[FromUri] long param2, [FromBody]Models.Person input, int id = 0)
        //{
        //    bool found = false;
        //    //using (var db = new MoviesDB())
        //    //{
        //    //    found = (db.Users.FirstOrDefault(u => u.Password == param2.ToString() && u.Username == paramId.ToString()) != null);
        //    //    //db.Users.Add(new User { Id = 3, Username = "u", Password = "p" });
        //    //    //db.SaveChanges();
        //    //}
        //    //    //return "PostTestTickle" + "Your param1 " + paramId + System.Environment.NewLine +
        //    //    //    "Your param2 " + param2 + System.Environment.NewLine +
        //    //    //    "Your body: "+ input.FamilyName + input.Name;
        //    //    input.Name = Thread.CurrentPrincipal.Identity.Name;




        //    return found;

        //}
        [HttpGet]
        [Route("GetTestTickle")]
        public string GetTestTickle()
        {
            return "GetTestTickle";
        }
        [HttpPut]
        [Route("PutTestTickle")]
        public string PutTestTickle()
        {
            return "PutTestTickle";
        }
        [HttpDelete]
        [Route("DeleteTestTickle")]
        public string DeleteTestTickle()
        {
            return "DeleteTestTickle";
        }
    }
}
