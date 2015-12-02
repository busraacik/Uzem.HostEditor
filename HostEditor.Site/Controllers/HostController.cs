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
        private HostEditorEntities1 db = new HostEditorEntities1();

        // GET: Host
        [HttpGet]       
        public ActionResult Index()
        {
            List<string>searchKeyword = new List<string>();
            searchKeyword.Add("Please choose category which they want");
            searchKeyword.Add("HostName");
            searchKeyword.Add("IP");
            searchKeyword.Add("Description");
            searchKeyword.Add("Name");

            ViewBag.searchKeyword = new SelectList(searchKeyword);
                
            var host = db.Host.Include(h => h.Category);
            
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
            Host host = db.Host.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            return View(host);
        }

        // GET: Host/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name");
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
                ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", host.CategoryId);
                return View(host);
               
            }
                db.Host.Add(host);
                db.SaveChanges();
                
                return RedirectToAction("Index");
        }

       
        // GET: Host/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = db.Host.Find(id);
            if (host == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", host.CategoryId);
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
                db.Entry(host).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Category, "CategoryId", "Name", host.CategoryId);
            return View(host);
        }

        // GET: Host/Delete/5
        public ActionResult Delete(int? id)
        {            
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Host host = db.Host.Find(id);
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
            Host host = db.Host.Find(id);
            db.Host.Remove(host);
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
