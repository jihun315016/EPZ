using Microsoft.AspNetCore.Mvc;

namespace EPZ.Web.Controllers
{
    public class NaverNewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //[HttpPost]
        public IActionResult Get()
        {
            return View();
        }
    }
}
