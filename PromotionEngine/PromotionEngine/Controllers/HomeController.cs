using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace PromotionEngineDemo.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
