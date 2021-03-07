using MvcStok.BusinessProcess;
using MvcStok.Models.Entity;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{

    //[AllowAnonymous]
    public class RaporlamaController : Controller
    {
        // GET: Raporlama
        private SatısManager satısManager = new SatısManager();
        private UrunManager urunManager = new UrunManager();
        private MusteriManager musteriManager = new MusteriManager();
        private DurumManager durumManager = new DurumManager();
        public ActionResult Index()
        {
            ViewBag.urunler = urunManager.Listeleme();
            ViewBag.musteriler = musteriManager.Listeleme();
            ViewBag.satısdurumlar = durumManager.Listeleme();
            return View();
        }

        public ActionResult MusDetails(int id) {

            List<TBLSATISLAR> musteriRapor = satısManager.Listeleme().Where(m => m.MUSTERI == id).ToList();
            ViewBag.musteri = musteriManager.findById(id).MUSTERIAD + " " + musteriManager.findById(id).MUSTERISOYAD;


            return View(musteriRapor);
        }

        public ActionResult UrunDetails(int id) {

            List<TBLSATISLAR> urunRapor = satısManager.Listeleme().Where(m => m.URUN == id).ToList();
            ViewBag.urun = urunManager.findById(id).URUNAD + " " + urunManager.findById(id).MARKA;
            return View(urunRapor);
        }


        public ActionResult StokDetails()
        {


            return View();
        }


        public ActionResult SatısDurumDetails(int id)
        {
            List<TBLSATISLAR> satısDurumRapor = satısManager.Listeleme().Where(m => m.DURUM == durumManager.findById(id).SATISDURUMAD).ToList();
            ViewBag.satısDurum = durumManager.findById(id).SATISDURUMAD;

            return View(satısDurumRapor);
        }
    }
}