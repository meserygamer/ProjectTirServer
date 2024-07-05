using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectTirServer.Controllers
{
    [Controller]
    [Route("ServerChecker")]
    public class ServerCheckController : Controller
    {
        [HttpGet]
        [Route("CheckServerState")]
        public IActionResult CheckServerState() => Ok("Server is running");
    }
}
