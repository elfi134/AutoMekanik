using AutoMekanikV3Final.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AutoMekanikV3Final.Controllers
{
    public class CarsController : Controller
    {
        private static DB _db;
        public CarsController(DB db)
        {
            _db = db;
        }

        // GET: CarsController
        public ActionResult Index()
        {
            List<Cars> list = new List<Cars>();
            list = _db.Cars.ToList();
            return View(list);
        }

        // GET: CarsController/Details/5
        public ActionResult Details(int id)
        {
            var makina = _db.Cars.Where(x=>x.Numri.Equals(id)).FirstOrDefault();
            return View(makina);
        }

        // GET: CarsController/Create
        public ActionResult Create()
        {
            var kategori = _db.kategori.ToList();
            var kat_Sel_list = new SelectList(kategori, "Numri", "Titulli");
            ViewBag.kategori = kat_Sel_list;
            return View();
        }

        // POST: CarsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cars newCars)
        {
            try
            {
                _db.Cars.Add(newCars);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Edit/5
        public ActionResult Edit(int id)
        {
            var carNeNdryshim = _db.Cars.Find(id);

            var kategori = _db.kategori.ToList();
            var kat_Sel_list = new SelectList(kategori, "Numri", "Titulli", carNeNdryshim.Numri);
            ViewBag.kategori = kat_Sel_list;
            return View(carNeNdryshim);
        }

        // POST: CarsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cars carNeNdryshim)
        {
            try
            {
                var carOrigjinale = _db.Cars.Find(carNeNdryshim.Numri);
                carOrigjinale.Make = carNeNdryshim.Make;
                carOrigjinale.Model = carNeNdryshim.Model;
                carOrigjinale.Year = carNeNdryshim.Year;
                carOrigjinale.KategoriaNumri = carNeNdryshim.KategoriaNumri;
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CarsController/Delete/5
        public ActionResult Delete(int id)
        {
            var makinaNeFshirje = _db.Cars.Find(id);
            return View(makinaNeFshirje);
        }

        // POST: CarsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                var makinaNeFshirje = _db.Cars.Find(id);
                _db.Cars.Remove(makinaNeFshirje);
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
