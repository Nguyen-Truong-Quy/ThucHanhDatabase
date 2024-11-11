using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseThucHanh.Models;

namespace DatabaseThucHanh.Areas.Admin.Controllers
{
    public class CategoriesController : Controller
    {
        private MyStoreEntities db = new MyStoreEntities();

        // GET: Admin/Categories: lấy dữ liệu từ bảng catergories trong database
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: Admin/Categories/Details/5
        //details: lấy chi tiết 1 bản ghi có CategoriesID = id 
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id); //hàm find của linq
            if (category == null)
            {
                return HttpNotFound(); // mã lỗi 404
            }
            return View(category);
        }

        // GET: Admin/Categories/Create
        // lấy 1 bảng ghi từ database và hiển thị lên form create
        //load form view 
        [HttpGet]
         public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Categories/Create
        //Lưu dữ liệu nhập vào từ form create vào database
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken] // đẩy dữ liệu lên server , chỉ ấn 1 lần
        public ActionResult Create([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid) // nếu dữ liệu đúng sẽ thêm bản ghi vào
            {
                db.Categories.Add(category); // hàm add là 1 hàm mặc định 
                db.SaveChanges();
                return RedirectToAction("Index"); // lưu xog sẽ tự động quay về form index 
            }

            return View(category); // nếu sai thì tự động load lại form category
        }

        // GET: Admin/Categories/Edit/5
        // lấy dữ liệu từ 1 danh mục đã có sao cho CategoryID = id 
        public ActionResult Edit(int? id)
        {
            //Details(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,CategoryName")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Admin/Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
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
