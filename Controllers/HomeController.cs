using Microsoft.AspNetCore.Mvc;

namespace SpringFestivalService.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController
    {
        [HttpGet]
        public ActionResult Ping()
        {
            return new OkResult();
        }
    }
}