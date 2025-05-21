using Examen.ApplicationCore.Domain;
using Examen.ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Examen.UI.Web.Controllers
{
    public class EquipementController : Controller
    {
        IServiceEquipement seqp;
        IServiceStudio sstd;
        public EquipementController(IServiceEquipement seqp, IServiceStudio sstd)
        {
            this.seqp = seqp;
            this.sstd = sstd;
        }

        // GET: EquipementController
        public ActionResult Index()
        {
            return View(seqp.GetMany());
        }

        // GET: EquipementController/Details/5
        public ActionResult Details(int id)
        {
            return View(seqp.GetById(id));
        }

        // GET: EquipementController/Create
        public ActionResult Create()
        {
            ViewBag.lsStudio = new SelectList(sstd.GetMany(), "StudioId", "NomStudio");
            return View();
        }

        // POST: EquipementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Equipement collection, IFormFile PhotoImg)
        {
            collection.PhotoEquipement = PhotoImg.FileName;
            if (PhotoImg != null)
            {
                var path = Path.Combine(Directory.GetCurrentDirectory(),
                    "wwwroot", "uploads", PhotoImg.FileName);
                Stream stream = new FileStream(path, FileMode.Create);
                PhotoImg.CopyTo(stream);
            }
            seqp.Add(collection);
            seqp.Commit();
            return RedirectToAction(nameof(Index));
        }

        // GET: EquipementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EquipementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EquipementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EquipementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
