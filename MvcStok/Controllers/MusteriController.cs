using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcStok.BusinessProcess;
using MvcStok.Models.Entity;
using PagedList;

namespace MvcStok.Controllers
{
    //[AllowAnonymous]
    public class MusteriController : Controller
    {
        // GET: Musteri
        //MvcDbStokEntities db = new MvcDbStokEntities();
        MusteriManager musteriManager = new MusteriManager();
        public ActionResult Index()
        {

            var degerler = musteriManager.Listeleme();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniMusteri() {

            return View();
        }
        [HttpPost]
        public ActionResult YeniMusteri(TBLMUSTERILER p1)
        {

            if (!ModelState.IsValid)
            {
                //ViewBag.dgr = kategoriManager.ListByNonIsActive();

                return View();
            }
            musteriManager.Ekle(p1);
          return  RedirectToAction("Index");
        }

        public ActionResult SIL(int id) {

            musteriManager.Sil(id);

            return RedirectToAction("Index");
        }

        public ActionResult MusteriGetir(int id) {

            
            return View(musteriManager.findById(id));


        }
        public ActionResult Guncelle(TBLMUSTERILER p1)
        {
            if (!ModelState.IsValid)
            {
                //ViewBag.dgr = kategoriManager.ListByNonIsActive();

                return View("MusteriGetir");
            }

            musteriManager.Guncelle(p1);

            return RedirectToAction("Index");
        }


    }
}