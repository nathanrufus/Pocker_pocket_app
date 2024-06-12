using Microsoft.AspNetCore.Mvc;

namespace PokerPocket.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
