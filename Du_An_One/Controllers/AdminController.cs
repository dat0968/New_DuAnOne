using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Du_An_One.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public IActionResult TongQuan()
        {
            return View();
        }

    }
}
