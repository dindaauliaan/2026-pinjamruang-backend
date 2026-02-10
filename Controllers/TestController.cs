using Microsoft.AspNetCore.Mvc;

namespace PinjamRuang.Controllers
{
    [ApiController]
    [Route("api/test")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("API Pinjam Ruang jalan 🚀");
        }
    }
}
