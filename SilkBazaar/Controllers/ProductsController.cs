using System;
using System.Net;
using System.Web.Mvc;

using SilkBazaar.Models;

namespace SilkBazaar.Controllers
{
    public class ProductsController : Controller
    {
        // GET: /Products/
        public ActionResult Index()
        {
            return View(Product.GetAll());
        }

        // GET: /Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = Product.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // GET: /Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Price,Quantity")] Product product)
        {
            if (this.ModelState.IsValid)
            {
                product.Id = Guid.NewGuid();
                product.Add();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: /Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = Product.Get(id);
            if (product == null)
            {
                return HttpNotFound();
            }

            return View(product);
        }

        // POST: /Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Price,Quantity")] Product product)
        {
            if (this.ModelState.IsValid)
            {
                product.Update();

                return RedirectToAction("Index");
            }

            return View(product);
        }

        // GET: /Products/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Product product = Product.Get(id);
            if (product == null)
            {
                return this.HttpNotFound();
            }

            return View(product);
        }

        // POST: /Products/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(Guid id)
        {
            Product product = Product.Get(id);
            product.Delete();

            return RedirectToAction("Index");
        }
    }
}
