using KendoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoMVC.Controllers
{
    public class ExamenController : Controller
    {
        // GET: Examen
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult IndexGetData()
        {
            List<AreaViewModel> lst = null;
            using (ExamenEntities db = new ExamenEntities())
            {
                lst = (from d in db.Areas
                       orderby d.IdArea
                       select new AreaViewModel
                       {
                           IdArea = d.IdArea,
                           Nombre = d.Nombre,
                           Descripcion = d.Descripcion
                       }).ToList();
            }
            return Json(lst, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult Agregar(AddAreaViewModel model)
        {
            int response = -1;
            try
            {
                using (var db = new ExamenEntities())
                {
                    Area oAreas = new Area();
                    oAreas.Nombre = model.Nombre;
                    oAreas.Descripcion = model.Descripcion;
                    db.Areas.Add(oAreas);
                    db.SaveChanges();
                    response = oAreas.IdArea;
                }

            }
            catch (Exception ex)
            {
                
            }
            return Content(response.ToString());
        }

        [HttpPost]
        public ActionResult Editar(EditAreaViewModel model)
        {
            int response = -1;
            try
            {
                using (var db = new ExamenEntities())
                {
                    Area oAreas = db.Areas.Find(model.IdArea);
                    oAreas.Nombre = model.Nombre;
                    oAreas.Descripcion = model.Descripcion;
                    db.Entry(oAreas).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    response = oAreas.IdArea;
                }
            }
            catch (Exception ex)
            {
                
            }
            return Content(response.ToString());
        }

        [HttpPost]
        public ActionResult Eliminar(int Id)
        {
            int response = -1;
            try
            {
                using (var db = new ExamenEntities())
                {
                    Area oAreas = db.Areas.Find(Id);
                    db.Areas.Remove(oAreas);
                    db.SaveChanges();
                    response = 1;
                }
            }
            catch (Exception ex)
            {

            }
            return Content(response.ToString());
        }

    }
}