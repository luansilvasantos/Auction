using Microsoft.AspNetCore.Mvc;

namespace Auction.API.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
