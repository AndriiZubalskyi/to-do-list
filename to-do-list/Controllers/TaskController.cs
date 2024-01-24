using Microsoft.AspNetCore.Mvc;

namespace to_do_list.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
