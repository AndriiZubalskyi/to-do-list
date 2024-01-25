using Microsoft.AspNetCore.Mvc;
using to_do_list.Data;

namespace to_do_list.Controllers
{
    public class TaskController : Controller
    {
        private readonly ApplicationDBContext _db;

        public TaskController(ApplicationDBContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Models.Task> tasksList = _db.Tasks;
            return View(tasksList);
        }
    }
}
