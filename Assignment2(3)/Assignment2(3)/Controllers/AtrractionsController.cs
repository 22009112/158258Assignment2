using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Assignment2_3_.Data;
using Assignment2_3_.Models;
using Assignment2_3_.ViewModels;
using PagedList;

namespace Assignment2_3_.Controllers
{
    public class AtrractionsController : Controller
    {
        private Assignment2_3_Context db = new Assignment2_3_Context();

        // GET: Atrractions

        public ActionResult Index(string city, string search, int? page)
        {
            //instantiate a new view model
            AtrractionIndexViewModel viewModel = new AtrractionIndexViewModel();
            var attractions = db.Atrractions.Include(p => p.City);
            //Search
            if (!String.IsNullOrEmpty(search))
            {
                attractions = attractions.Where(p => p.Name.Contains(search) ||
                p.Address.Contains(search) ||
                p.City.Name.Contains(search));
                viewModel.Search = search;
            }
            //Filter
            viewModel.CityWithCount = from matchingProducts in attractions
                                      where
                                      matchingProducts.CityID != null
                                      group matchingProducts by
                                      matchingProducts.City.Name into
                                      catGroup
                                      select new CityWithCount()
                                      {
                                          CityName = catGroup.Key,
                                          AttractionCount = catGroup.Count()
                                      };//Count
            if (!String.IsNullOrEmpty(city))
            {
                attractions = attractions.Where(p => p.City.Name == city);
                viewModel.City = city;
            }
            //Sort and Page
            attractions = attractions.OrderBy(p => p.Name);
            const int PageItems = 4;
            int currentPage  = (page ?? 1);
            viewModel.Atrractions = attractions.ToPagedList(currentPage,PageItems);
            return View(viewModel);
        }

        // GET: Atrractions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atrraction atrraction = db.Atrractions.Find(id);
            if (atrraction == null)
            {
                return HttpNotFound();
            }
            return View(atrraction);
        }

        // GET: Atrractions/Create
        public ActionResult Create()
        {
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name");
            return View();
        }

        // POST: Atrractions/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Address,CityID")] Atrraction atrraction)
        {
            if (ModelState.IsValid)
            {
                db.Atrractions.Add(atrraction);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", atrraction.CityID);
            return View(atrraction);
        }

        // GET: Atrractions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atrraction atrraction = db.Atrractions.Find(id);
            if (atrraction == null)
            {
                return HttpNotFound();
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", atrraction.CityID);
            return View(atrraction);
        }

        // POST: Atrractions/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Address,CityID")] Atrraction atrraction)
        {
            if (ModelState.IsValid)
            {
                db.Entry(atrraction).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CityID = new SelectList(db.Cities, "ID", "Name", atrraction.CityID);
            return View(atrraction);
        }

        // GET: Atrractions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Atrraction atrraction = db.Atrractions.Find(id);
            if (atrraction == null)
            {
                return HttpNotFound();
            }
            return View(atrraction);
        }

        // POST: Atrractions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Atrraction atrraction = db.Atrractions.Find(id);
            db.Atrractions.Remove(atrraction);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
