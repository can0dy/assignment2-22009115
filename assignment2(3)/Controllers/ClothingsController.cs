using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using assignment2_3_.Data;
using assignment2_3_.Models;
using assignment2_3_.ViewModels;
using PagedList;

namespace assignment2_3_.Controllers
{
    public class ClothingsController : Controller
    {
        private assignment2_3_Context db = new assignment2_3_Context();

        // GET: Clothings
        public ActionResult Index(string category, string search,int? page)
        {
            ClothingIndexViewModel viewModel = new ClothingIndexViewModel();

            var clothings = db.Clothings.Include(p => p.Category);
            if (!String.IsNullOrEmpty(search))
            {
                clothings = clothings.Where(p => p.Name.Contains(search) ||
                p.Type.Contains(search) ||
                p.Category.Name.Contains(search));
                /*ViewBag.Search = search;*/
                viewModel.Search = search;
            }
            viewModel.CatsWithCount = from matchingClothing in clothings
                                      where
                                      matchingClothing.CategoryID != null
                                      group matchingClothing by
                                      matchingClothing.Category.Name into
                                      catGroup
                                      select new CategoryWithCount()
                                      {
                                          CategoryName = catGroup.Key,
                                          ClothingCount = catGroup.Count()
                                      };
            /*var categories = clothings.OrderBy(p => p.Category.Name).Select(p
           => p.Category.Name).Distinct();*/
            if (!String.IsNullOrEmpty(category))
            {
                clothings = clothings.Where(p => p.Category.Name == category);
                viewModel.Category= category;
            }
            clothings = clothings.OrderBy(p => p.Name);
            const int PageItems = 6;
            int currentPage = (page ?? 1);
            viewModel.Clothings = clothings.ToPagedList(currentPage, PageItems);
            /*ViewBag.Category = new SelectList(categories);
            return View(clothings.ToList());*/
            /*viewModel.Clothings = clothings;*/
            return View(viewModel);
        }

        // GET: Clothings/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // GET: Clothings/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name");
            return View();
        }

        // POST: Clothings/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Price,Type,CategoryID")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Clothings.Add(clothing);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", clothing.CategoryID);
            return View(clothing);
        }

        // GET: Clothings/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", clothing.CategoryID);
            return View(clothing);
        }

        // POST: Clothings/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性；有关
        // 更多详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Price,Type,CategoryID")] Clothing clothing)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clothing).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "Name", clothing.CategoryID);
            return View(clothing);
        }

        // GET: Clothings/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clothing clothing = db.Clothings.Find(id);
            if (clothing == null)
            {
                return HttpNotFound();
            }
            return View(clothing);
        }

        // POST: Clothings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clothing clothing = db.Clothings.Find(id);
            db.Clothings.Remove(clothing);
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
