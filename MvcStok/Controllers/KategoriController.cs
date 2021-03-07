using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.Models.Entity;
using MvcStok.BusinessProcess;

using PagedList;

namespace MvcStok.Controllers
{
    //[AllowAnonymous]
    public class KategoriController : Controller
    {
        // GET: Kategori
        
        KategoriManager kategoriManager = new KategoriManager();
        private MvcDbStokEntities db = DatabaseController.getSingleton().getDB();

        public ActionResult Index()
        {
            

            var degerler = kategoriManager.Listeleme();
            return View(degerler);
        }


        [HttpGet]
        public ActionResult YeniKategori()
        {


            return View();
        }

        [HttpPost]
        public ActionResult YeniKategori(TBLKATEGORILER p1) {
           
            if (!ModelState.IsValid)
            {
                //ViewBag.dgr = kategoriManager.ListByNonIsActive();

                return View("YeniKategori");
            }
            kategoriManager.Ekle(p1);

            return RedirectToAction("Index");
        }

        public JsonResult SIL(int id) {

            
            bool varMı = db.TBLURUNLER.Any(u => u.URUNKATEGORI == id);
            //ViewBag.deneme = varMı;

            if (!varMı) {
                kategoriManager.Sil(id);
                
                return Json(true, JsonRequestBehavior.AllowGet);
            }

            return Json(false, JsonRequestBehavior.AllowGet);

        }

        public ActionResult KategoriGetir(int id) {

            return View(kategoriManager.findById(id));
        
        }

        public ActionResult Guncelle(TBLKATEGORILER p1) {


            if (!ModelState.IsValid)
            {
                //ViewBag.dgr = kategoriManager.ListByNonIsActive();

                return View("KategoriGetir");
            }
            kategoriManager.Guncelle(p1);
            return RedirectToAction("Index");
        }
    }
}