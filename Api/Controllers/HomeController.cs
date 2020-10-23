using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        [HttpGet]
        public IActionResult Index()
        {
            return Ok(new { message = "Welcome to Asp .Net core Api" });
        }
    }
}
