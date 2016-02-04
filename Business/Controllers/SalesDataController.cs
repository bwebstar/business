using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Business.Models;

namespace Business.Controllers
{
    [Authorize]
    public class SalesDataController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalesData
        public ActionResult Index()
        {
            return View(db.SalesData.ToList());
        }

        // GetSalesData JSON API
        public JsonResult GetSalesData()
        {
            List<SalesData> sd = new List<SalesData>();

            sd = db.SalesData.OrderBy(a => a.Year).ToList();

            var chartData = new object[sd.Count + 1];
            chartData[0] = new object[]{
                "Year",
                "Kitchen & Bath",
                "Home & Garden",
                "Electronics",
                "Books & Media"
            };

            int j = 0;
            foreach (var i in sd)
            {
                j++;
                chartData[j] = new object[] { i.Year, i.KitchenAndBath, i.HomeAndGarden, i.Electronics, i.BooksAndMedia };
            }

            return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: SalesData/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return HttpNotFound();
            }
            return View(salesData);
        }

        // GET: SalesData/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesData/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Year,KitchenAndBath,HomeAndGarden,Electronics,BooksAndMedia")] SalesData salesData)
        {
            if (ModelState.IsValid)
            {
                db.SalesData.Add(salesData);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesData);
        }

        // GET: SalesData/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return HttpNotFound();
            }
            return View(salesData);
        }

        // POST: SalesData/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Year,KitchenAndBath,HomeAndGarden,Electronics,BooksAndMedia")] SalesData salesData)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesData).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesData);
        }

        // GET: SalesData/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesData salesData = db.SalesData.Find(id);
            if (salesData == null)
            {
                return HttpNotFound();
            }
            return View(salesData);
        }

        // POST: SalesData/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesData salesData = db.SalesData.Find(id);
            db.SalesData.Remove(salesData);
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
