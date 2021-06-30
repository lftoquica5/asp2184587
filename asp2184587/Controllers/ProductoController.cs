using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Rotativa;
using asp2184587.Models;

namespace asp2184587.Controllers
{
    public class ProductoController : Controller
    {
        // GET: producto

        public ActionResult Index()
        {
            using (var db = new inventarioEntities())
            {
                return View(db.producto.ToList());
            }
        }

        public static string NombreProveedor(int? idproveedor)
        {
            using (var db = new inventarioEntities())
            {
                return db.proveedor.Find(idproveedor).nombre;
            }
        }

        public ActionResult ListarProveedores()
        {
            using (var db = new inventarioEntities())
            {
                return PartialView(db.proveedor.ToList());
            }
        }

        //para el create son dos metodos 
        public ActionResult create()
        {
            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult create(producto producto)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                using (var db = new inventarioEntities())
                {
                    db.producto.Add(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }


        public ActionResult Edit(int id)
        {
            using (var db = new inventarioEntities())
            {
                producto productoEdit = db.producto.Where(a => a.id == id).FirstOrDefault();
                return View(productoEdit);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(producto productoEdit)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    producto oldproduct = db.producto.Find(productoEdit.id);
                    oldproduct.nombre = productoEdit.nombre;
                    oldproduct.cantidad = productoEdit.cantidad;
                    oldproduct.descripcion = productoEdit.descripcion;
                    oldproduct.percio_unitario = productoEdit.percio_unitario;
                    oldproduct.id_proveedor = productoEdit.id_proveedor;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "error" + ex);
                return View();

            }
        }

        public ActionResult Details(int id)
        {
            using (var db = new inventarioEntities())
            {
                return View(db.producto.Find(id));

            }
        }

        public ActionResult Delete(int id)
        {
            try
            {
                using (var db = new inventarioEntities())
                {
                    producto producto = db.producto.Find(id);
                    db.producto.Remove(producto);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                ModelState.AddModelError("", "error" + ex);
                return View();
            }
        }

        public ActionResult reporte()
        {
            var db = new inventarioEntities();
            var query = from tabProvedor in db.proveedor
                        join tabProducto in db.producto on tabProvedor.id equals tabProducto.id_proveedor
                        select new reporte
                        {
                            nombreProveedor = tabProvedor.nombre,
                            telefonoProveedor = tabProvedor.telefono,
                            direccionProveedor = tabProvedor.direccion,
                            nombreProducto = tabProducto.nombre,
                            precioProducto = tabProducto.percio_unitario
                        };
            return View(query);
        }

        public ActionResult ImprimirReporte()
        {
            return new ActionAsPdf("Reporte") { FileName = "Reporte.pdf" };
        }


    }

}

  