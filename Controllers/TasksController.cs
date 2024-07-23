using AutoMekanikV3Final.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMekanikV3Final.Controllers
{
    public class TasksController : Controller
    {
        private static DB _db;
        public TasksController(DB db)
        {
            _db = db;
        }
        // GET: TasksController
        public ActionResult Index()
        {
            List<Tasks> list = new List<Tasks>();
            list = _db.Tasks.ToList();
            return View(list);
        }

        // GET: TasksController/Details/5
        public ActionResult Details(int id)
        {
            var Taski = _db.Tasks.Where(x => x.Numri.Equals(id)).FirstOrDefault();
            return View(Taski);
        }

        // GET: TasksController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TasksController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Tasks NewTask)
        {
            try
            {
                _db.Tasks.Add(NewTask);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TasksController/Edit/5
        public ActionResult Edit(int id)
        {
            var TaskNeNdryshim = _db.Tasks.Find(id);
            return View(TaskNeNdryshim);
        }

        // POST: TasksController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Tasks TaskNeNdryshim)
        {
            try
            {
                var TaskiOrigjinale = _db.Tasks.Find(TaskNeNdryshim.Numri);
                TaskiOrigjinale.Task = TaskNeNdryshim.Task;
                TaskiOrigjinale.Time = TaskNeNdryshim.Time;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: TasksController/Delete/5
        public ActionResult Delete(int id)
        {
            var taskiNeFshirje = _db.Tasks.Find(id);
            return View(taskiNeFshirje);
           
        }

        // POST: TasksController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var taskiNeFshirje = _db.Tasks.Find(id);
                _db.Tasks.Remove(taskiNeFshirje);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
