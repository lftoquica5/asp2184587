using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using asp2184587.Models;

namespace asp2184587.Controllers
{
    public class ProveedorController : Controller
    {
        // GET: Proveedor
        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.proveedor.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(proveedor proveedor)
        {
            if (!ModelState.IsValid)
                return View();
            try//verdadero
            {
                using (var db = new inventarioEntities())
                {
                    db.proveedor.Add(proveedor);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)//osino retorna aquiiiii el error
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                var findUser = db.proveedor.Find(id);
                return View(findUser);
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    proveedor FindUser = db.proveedor.Where(a => a.id == id).FirstOrDefault();
                    return View(FindUser);
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(proveedor EditUser)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    proveedor proveedor = db.proveedor.Find(EditUser.id);
                    proveedor.nombre = EditUser.nombre;
                    proveedor.direccion = EditUser.direccion;
                    proveedor.telefono = EditUser.telefono;
                    proveedor.nombre_contacto = EditUser.nombre_contacto;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }
        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    var findUser = db.proveedor.Find(id);
                    db.proveedor.Remove(findUser);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "Error" + ex);
                return View();
            }
        }

    }
}
