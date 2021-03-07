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
    public class UrunController : Controller
    {
        // GET: Urun
        //private MvcDbStokEntities db = new MvcDbStokEntities();
        private UrunManager urunManager = new UrunManager();
        private KategoriManager kategoriManager = new KategoriManager();

        
        public ActionResult Index()
        {

            IEnumerable<TBLURUNLER> degerler = urunManager.Listeleme();

            return View(degerler);
        }

        
        [HttpGet]
        public ActionResult YeniUrun()
        {
            

            ViewBag.dgr = kategoriManager.ListByIsActive();
            return View();
        }

        [HttpPost]
        public ActionResult YeniUrun(TBLURUNLER p1)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.dgr = kategoriManager.ListByIsActive();

                return View();
            }
            urunManager.Ekle(p1);
            return RedirectToAction("Index");
        }

        public ActionResult SIL(int id)
        {
            if (true) { 
            urunManager.Sil(id); }
            return RedirectToAction("Index");
        }

        public ActionResult UrunGetir(int id)
        {

            var urun = urunManager.findById(id);

                                        

            ViewBag.dgr = kategoriManager.ListByIsActive();

            return View(urun);

        }
      
        public ActionResult Guncelle(TBLURUNLER p1)
        {

            if (!ModelState.IsValid)
            {
                ViewBag.dgr = kategoriManager.ListByIsActive();

                return View("UrunGetir");
            }
            urunManager.Guncelle(p1);
           return RedirectToAction("Index");
        }
    }
}
