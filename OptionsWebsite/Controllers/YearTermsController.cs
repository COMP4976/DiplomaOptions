﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OptionsWebsite.Models.BCITModels;

namespace OptionsWebsite.Controllers
{
    public class YearTermsController : Controller
    {
        private BCITContext db = new BCITContext();

        // GET: YearTerms
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            return View(db.YearTerms.ToList());
        }

        // GET: YearTerms/Details/5
        [Authorize(Roles = "Admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // GET: YearTerms/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: YearTerms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                db.YearTerms.Add(yearTerm);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(yearTerm);
        }

        // GET: YearTerms/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // POST: YearTerms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit([Bind(Include = "YearTermId,Year,Term,IsDefault")] YearTerm yearTerm)
        {
            if (ModelState.IsValid)
            {
                db.Entry(yearTerm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(yearTerm);
        }

        // GET: YearTerms/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            YearTerm yearTerm = db.YearTerms.Find(id);
            if (yearTerm == null)
            {
                return HttpNotFound();
            }
            return View(yearTerm);
        }

        // POST: YearTerms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult DeleteConfirmed(int id)
        {
            YearTerm yearTerm = db.YearTerms.Find(id);
            db.YearTerms.Remove(yearTerm);
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
