using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using sysOnlineCart.Models;
using Microsoft.AspNet.Identity;

namespace sysOnlineCart.Controllers
{
    public class RegisterClientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RegisterClient
        public ActionResult Index()
        {
            return View(db.Clients.ToList());
        }

        // GET: RegisterClient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client registerClientViewModel = db.Clients.Find(id);
            if (registerClientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registerClientViewModel);
        }

        // GET: RegisterClient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RegisterClient/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( RegisterClientViewModel model)
        {
            if (ModelState.IsValid)
            {
                string userid = User.Identity.GetUserId();
                var user = new Client { clientId = userid, clientName = model.clientName, phone =model.phone };
                db.Clients.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            var client = db.Clients.ToList();
            return View(client);
        }

        // GET: RegisterClient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client registerClientViewModel = db.Clients.Find(id);
            if (registerClientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registerClientViewModel);
        }

        // POST: RegisterClient/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Client registerClientViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registerClientViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }

        // GET: RegisterClient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RegisterClientViewModel registerClientViewModel = db.RegisterClientViewModels.Find(id);
            if (registerClientViewModel == null)
            {
                return HttpNotFound();
            }
            return View(registerClientViewModel);
        }

        // POST: RegisterClient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RegisterClientViewModel registerClientViewModel = db.RegisterClientViewModels.Find(id);
            db.RegisterClientViewModels.Remove(registerClientViewModel);
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
