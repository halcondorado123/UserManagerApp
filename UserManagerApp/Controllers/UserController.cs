using Microsoft.AspNetCore.Mvc;

namespace UserManagerApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
