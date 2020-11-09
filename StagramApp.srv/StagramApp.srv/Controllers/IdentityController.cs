using Microsoft.AspNetCore.Mvc;

namespace StagramApp.srv.Controllers
{
    public class IdentityController : Controller
    {
        [Route(nameof(Register))]
        public IActionResult Register()
        {
            return Ok("Im Online");
        }
    }
}