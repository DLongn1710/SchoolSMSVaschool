using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SchoolSMSVaschool.Model;
using SchoolSMSVaschool.Models;

namespace SchoolSMSVaschool.Code
{
    public class MenuStudentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MenuStudents
        public ActionResult Index()
        {
            return View(db.MenuStudents.ToList());
        }

        // GET: MenuStudents/Details/5
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuStudent menuStudent = db.MenuStudents.Find(id);
            if (menuStudent == null)
            {
                return HttpNotFound();
            }
            return View(menuStudent);
        }

        // GET: MenuStudents/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MenuStudents/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Ma,Ma2,FullName,NgaySinh,GioiTinh,NoiSinh,DanToc,QuocTich,DiaChi,DienThoai,TenCha,DTCha,TenMe,DTMe,TrangThai,TinhTrang,Khoi,CoSo,ChinhSach,TenNguoiQuanHe,QuanHe,Note")] MenuStudent menuStudent)
        {
            if (ModelState.IsValid)
            {
                db.MenuStudents.Add(menuStudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(menuStudent);
        }

        // GET: MenuStudents/Edit/5
        public ActionResult Edit(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuStudent menuStudent = db.MenuStudents.Find(id);
            if (menuStudent == null)
            {
                return HttpNotFound();
            }
            return View(menuStudent);
        }

        // POST: MenuStudents/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Ma,Ma2,FullName,NgaySinh,GioiTinh,NoiSinh,DanToc,QuocTich,DiaChi,DienThoai,TenCha,DTCha,TenMe,DTMe,TrangThai,TinhTrang,Khoi,CoSo,ChinhSach,TenNguoiQuanHe,QuanHe,Note")] MenuStudent menuStudent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(menuStudent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(menuStudent);
        }

        // GET: MenuStudents/Delete/5
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MenuStudent menuStudent = db.MenuStudents.Find(id);
            if (menuStudent == null)
            {
                return HttpNotFound();
            }
            return View(menuStudent);
        }

        // POST: MenuStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            MenuStudent menuStudent = db.MenuStudents.Find(id);
            db.MenuStudents.Remove(menuStudent);
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
