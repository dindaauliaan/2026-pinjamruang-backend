using Microsoft.AspNetCore.Mvc;

namespace PinjamRuang.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Peminjaman Ruangan API is running 🚀");
        }
    }
}
