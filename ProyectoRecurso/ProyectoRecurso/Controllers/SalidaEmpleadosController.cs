using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoRecurso.Models;

namespace ProyectoRecurso.Controllers
{
    public class SalidaEmpleadosController : Controller
    {
        private RecursoEntities db = new RecursoEntities();

        // GET: SalidaEmpleados
        public ActionResult Index()
        {
            var salidaEmpleado = db.SalidaEmpleado.Include(s => s.Empleados);
            return View(salidaEmpleado.ToList());
        }

        // GET: SalidaEmpleados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleado.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleados/Create
        public ActionResult Create()
        {
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "Id", "Nombre");
            return View();
        }

        // POST: SalidaEmpleados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IdEmpleado,TipoSalida,Motivo,FechaSalaida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.SalidaEmpleado.Add(salidaEmpleado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdEmpleado = new SelectList(db.Empleados, "Id", "Nombre", salidaEmpleado.IdEmpleado);
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleado.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "Id", "Nombre", salidaEmpleado.IdEmpleado);
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IdEmpleado,TipoSalida,Motivo,FechaSalaida")] SalidaEmpleado salidaEmpleado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(salidaEmpleado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdEmpleado = new SelectList(db.Empleados, "Id", "Nombre", salidaEmpleado.IdEmpleado);
            return View(salidaEmpleado);
        }

        // GET: SalidaEmpleados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleado.Find(id);
            if (salidaEmpleado == null)
            {
                return HttpNotFound();
            }
            return View(salidaEmpleado);
        }

        // POST: SalidaEmpleados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SalidaEmpleado salidaEmpleado = db.SalidaEmpleado.Find(id);
            db.SalidaEmpleado.Remove(salidaEmpleado);
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
