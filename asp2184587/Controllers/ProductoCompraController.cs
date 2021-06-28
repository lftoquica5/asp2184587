﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using asp2184587.Models;

namespace asp2184587.Controllers
{
    public class ProductoCompraController : Controller
    {
        public ActionResult Index()
        {
            using (inventarioEntities db = new inventarioEntities())
            {
                return View(db.producto_compra.ToList());
            }
        }

        // GET: ProductoCompra/Details/5
        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                var findProduct = db.producto_compra.Find(id);
                return View(findProduct);
            }
        }

        public ActionResult listarProductos()
        {
            using (inventarioEntities db = new inventarioEntities())
            {
                return PartialView(db.producto.ToList());
            }
        }

        public ActionResult listarCompras()
        {
            using (inventarioEntities db = new inventarioEntities())
            {
                return PartialView(db.compra.ToList());
            }
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create(producto_compra producto_Compra)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (inventarioEntities db = new inventarioEntities())
                {
                    db.producto_compra.Add(producto_Compra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            try
            {
                using (inventarioEntities db = new inventarioEntities())
                {
                    producto_compra findProductBuy = db.producto_compra.Where(a => a.id == id).FirstOrDefault();
                    return View();
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto_compra editProducto_compra)
        {
            try
            {
                using (inventarioEntities db = new inventarioEntities())
                {
                    producto_compra producto_compra = db.producto_compra.Find(editProducto_compra.id);
                    producto_compra.id_compra = editProducto_compra.id_compra;
                    producto_compra.id_producto = editProducto_compra.id_producto;
                    producto_compra.cantidad = editProducto_compra.cantidad;

                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (inventarioEntities db = new inventarioEntities())
                {
                    var findProductoCompra = db.producto_compra.Find(id);
                    db.producto_compra.Remove(findProductoCompra);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error " + ex);
                return View();
            }
        }
    }
}


