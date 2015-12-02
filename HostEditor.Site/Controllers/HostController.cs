using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HostEditor.Models;

namespace HostEditor.Controllers
{
    public class HostController : Controller
    {
        private HEDb Db = new HEDb();

        // GET: Host
        [HttpGet]       
        public ActionResult Index(string Search)
        {
            ViewBag.Search = new SelectList(Search);     
            var host = Db.Host.Include(h => h.Category);    
            return View(host.ToList());
            
            
        }

        [HttpPost]
        public ActionResult searchKeyword(String kw)
        {
            string val = Request.Form["kw"];
            
            return View();
        }

        // GET: Host/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = Db.Host.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // GET: Host/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(Db.Category, "CategoryId", "Name");
            return View();
        }

        // POST: Host/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "HostId,HostName,IP,Description,CategoryId")] Host host)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.CategoryId = new SelectList(Db.Category, "CategoryId", "Name", host.CategoryId);
                return View(host);
               
            }
                Db.Host.Add(host);
                Db.SaveChanges();
                
                return RedirectToAction("Index");
        }

       
        // GET: Host/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = Db.Host.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(Db.Category, "CategoryId", "Name", host.CategoryId);
            return View(host);
        }

        // POST: Host/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "HostId,HostName,IP,Description,CategoryId")] Host host)
        {
            if (ModelState.IsValid)
            {
                Db.Entry(host).State = EntityState.Modified;
                Db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(Db.Category, "CategoryId", "Name", host.CategoryId);
            return View(host);
        }

        // GET: Host/Delete/5
        public ActionResult Delete(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = Db.Host.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // POST: Host/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Host host = Db.Host.Find(id);
            Db.Host.Remove(host);
            Db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
