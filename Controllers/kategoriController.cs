using AutoMekanikV3Final.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AutoMekanikV3Final.Controllers
{
    public class kategoriController : Controller
    {
        private static DB _db;
        public kategoriController(DB db)
        {
            _db = db;
        }
        public ActionResult Index()
        {
            List<kategori> list = new List<kategori>();
            list = _db.kategori.ToList();
            return View(list);
        }

        // GET: kategoriController/Details/5
        public ActionResult Details(int id)
        {
            var kategoria = _db.kategori.Where(x => x.Numri.Equals(id)).FirstOrDefault();
            return View(kategoria);
        }

        // GET: kategoriController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: kategoriController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(kategori newkategroi)
        {
            try
            {
                _db.kategori.Add(newkategroi);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: kategoriController/Edit/5
        public ActionResult Edit(int id)
        {
            var katNeNdryshim = _db.kategori.Find(id);
            return View(katNeNdryshim);
        }

        // POST: kategoriController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(kategori katNeNdryshim)
        {
            try
            {
                var katOrigjinale = _db.kategori.Find(katNeNdryshim.Numri);
                katOrigjinale.Titulli = katNeNdryshim.Titulli;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: kategoriController/Delete/5
        public ActionResult Delete(int id)
        {
            var katNeFshirje = _db.kategori.Find(id);
            return View(katNeFshirje);
        }

        // POST: kategoriController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var katNeFshirje = _db.kategori.Find(id);
                _db.kategori.Remove(katNeFshirje);
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
