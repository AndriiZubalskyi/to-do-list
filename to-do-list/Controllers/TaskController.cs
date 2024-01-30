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

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Task task)
        {
            if (ModelState.IsValid)
            {
                _db.Tasks.Add(task);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }
    }
}
