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
    public class SalesPersonSalesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: SalesPersonSales
        public ActionResult Index()
        {
            return View(db.SalesPersonSales.ToList());
        }

        // GetSalesData JSON API
        public JsonResult GetSalesPersonData()
        {
            List<SalesPersonSales> sd = new List<SalesPersonSales>();

            sd = db.SalesPersonSales.OrderBy(a => a.SalesPerson).ToList();

            var chartData = new object[sd.Count + 1];
            chartData[0] = new object[]{
                "Sales Person",
                "Software Sales",
                "Service Sales",
                "Support Sales"
            };

            int j = 0;
            foreach (var i in sd)
            {
                j++;
                chartData[j] = new object[] { i.SalesPerson, i.SoftwareSales, i.ServicesSales, i.SupportSales };
            }

            return new JsonResult { Data = chartData, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        // GET: SalesPersonSales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesPersonSales salesPersonSales = db.SalesPersonSales.Find(id);
            if (salesPersonSales == null)
            {
                return HttpNotFound();
            }
            return View(salesPersonSales);
        }

        // GET: SalesPersonSales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SalesPersonSales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SalesPerson,SoftwareSales,ServicesSales,SupportSales")] SalesPersonSales salesPersonSales)
        {
            if (ModelState.IsValid)
            {
                db.SalesPersonSales.Add(salesPersonSales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(salesPersonSales);
        }

        // GET: SalesPersonSales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesPersonSales salesPersonSales = db.SalesPersonSales.Find(id);
            if (salesPersonSales == null)
            {
                return HttpNotFound();
            }
            return View(salesPersonSales);
        }

        // POST: SalesPersonSales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SalesPerson,SoftwareSales,ServicesSales,SupportSales")] SalesPersonSales salesPersonSales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salesPersonSales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(salesPersonSales);
        }

        // GET: SalesPersonSales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalesPersonSales salesPersonSales = db.SalesPersonSales.Find(id);
            if (salesPersonSales == null)
            {
                return HttpNotFound();
            }
            return View(salesPersonSales);
        }

        // POST: SalesPersonSales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalesPersonSales salesPersonSales = db.SalesPersonSales.Find(id);
            db.SalesPersonSales.Remove(salesPersonSales);
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
