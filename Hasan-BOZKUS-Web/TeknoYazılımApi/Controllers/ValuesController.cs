using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TeknoYazılımApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public IActionResult adana()
        {
            return Ok();
        }
    }
}
