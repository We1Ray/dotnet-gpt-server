using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace netserver.Controllers
{
    [Route("[controller]")]
    public class HelloController : Controller
    {
        [HttpGet]
        public string Get()
        {
            return "Hello!";
        }

    }
}