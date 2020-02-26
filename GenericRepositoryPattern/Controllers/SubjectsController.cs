using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GenericRepositoryPattern.DAL;
using GenericRepositoryPattern.Models;

namespace GenericRepositoryPattern.Controllers
{
    public class SubjectsController : Controller
    {
        private _IAllRepository<Subject> db;
        public SubjectsController()
        {
            db = new AllRepository<Subject>();
        }


        // GET: Subjects
        public ActionResult Index()
        {
            var subjects = db.GetModel();
            return View(subjects.ToList());
        }

        // GET: Subjects/Details/5
        public ActionResult Details(int id)
        {
            var model = db.GetModelById(id);
            return View(model);
        }

        // GET: Subjects/Create
        public ActionResult Create()
        {
            ViewBag.ClassId = new SelectList(db.GetAllClass(), "ClassId", "Name");
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectId,Name,ClassId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.InsertModel(subject);
                db.Save();
                return RedirectToAction("Index");
            }

            ViewBag.ClassId = new SelectList(db.GetAllClass(), "ClassId", "Name", subject.ClassId);
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.GetModelById(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassId = new SelectList(db.GetAllClass(), "ClassId", "Name", subject.ClassId);
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectId,Name,ClassId")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                db.UpdateModel(subject);
                db.Save();
                return RedirectToAction("Index");
            }
            ViewBag.ClassId = new SelectList(db.GetAllClass(), "ClassId", "Name", subject.ClassId);
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.GetModelById(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.DeleteModel(id);
            db.Save();
            return RedirectToAction("Index");
        }
    
    }
}
