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
            if(task.Deadline.HasValue && task.Deadline <=  DateTime.UtcNow)
            {
                ModelState.AddModelError("deadline", "Deadline must be later than currend date and time.");
            }
            if (ModelState.IsValid)
            {
                _db.Tasks.Add(task);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //GET
        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0) 
            {
                return NotFound();
            }
            
            var taskToEdit = _db.Tasks.Find(id);

            if(taskToEdit == null)
            {
                return NotFound();
            }

            return View(taskToEdit);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Models.Task task)
        {
            if (task.Deadline.HasValue && task.Deadline <= DateTime.UtcNow)
            {
                ModelState.AddModelError("deadline", "Deadline must be later than currend date and time.");
            }
            if (ModelState.IsValid)
            {
                _db.Tasks.Update(task);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(task);
        }

        //GET
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var taskToDelete = _db.Tasks.Find(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            return View(taskToDelete);
        }

        //POST
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {
            var taskToDelete = _db.Tasks.Find(id);

            if (taskToDelete == null)
            {
                return NotFound();
            }

            _db.Tasks.Remove(taskToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
