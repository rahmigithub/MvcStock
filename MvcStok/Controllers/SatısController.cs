using MvcStok.BusinessProcess;
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.Controllers
{
    //[AllowAnonymous]
    public class SatısController : Controller
    {
        // GET: Satıs
        private SatısManager satısManager = new SatısManager();
        private UrunManager urunManager = new UrunManager();
        private MusteriManager musteriManager = new MusteriManager();
        private DurumManager durumManager = new DurumManager();
        public ActionResult Index()
        {
            IEnumerable<TBLSATISLAR> degerler = satısManager.Listeleme();
            return View(degerler);
        }

        [HttpGet]
        public ActionResult YeniSatıs() {


            ViewBag.urunler = urunManager.ListByIsActive();
            ViewBag.musteriler = musteriManager.ListByIsActive();
            return View();
        }

        [HttpPost]
        public ActionResult YeniSatıs(TBLSATISLAR p1)
        {
           
            p1.FIYAT = (urunManager.findById((int)p1.URUN).FIYAT)*(p1.ADET);
            p1.DURUM = durumManager.findById(1).SATISDURUMAD;

            var urunstokadedi = urunManager.findById((int)p1.URUN).STOK - p1.ADET;
            var urun = urunManager.findById((int)p1.URUN);

            if (urunstokadedi < 0)
            {
                //TempData["Message"] = "Bu ürüne ait istediğiniz miktarda stok yoktur";
                TempData["Message"] = "<script>alert('Bu ürüne ait istediğiniz miktarda stok yoktur ');</script>";
                return RedirectToAction("YeniSatıs");

            }
            else if (urunstokadedi == 0) {

                //TempData["Message"] = "Sipariş başarılı ancak Urunden 0 adet kaldığı için silinmiştir.";
                TempData["Message"] = "<script>alert('Sipariş başarılı ancak Urunden 0 adet kaldığı için silinmiştir.');</script>";

               
                urun.STOK = 0;
                urunManager.Guncelle(urun);
                urunManager.Sil((int)p1.URUN);
                satısManager.Ekle(p1);
                return RedirectToAction("Index");
            }


            urun.STOK = (byte?)urunstokadedi;
            urunManager.Guncelle(urun);
            satısManager.Ekle(p1);

            return RedirectToAction("Index");
        }

        public ActionResult Sil(int id) {

            
                satısManager.Sil(id);
            
            return RedirectToAction("Index");
        }

        public ActionResult SatısGetir(int id)
        {

            var satıs = satısManager.findById(id);

            ViewBag.urunler = urunManager.ListByIsActive();
            ViewBag.musteriler = musteriManager.ListByIsActive();
            ViewBag.satısdurum = durumManager.ListelemeSelectedListItem();

           
            return View(satıs);

        }

        public ActionResult Guncelle(TBLSATISLAR p1)
        {
            p1.FIYAT = (urunManager.findById((int)p1.URUN).FIYAT) * (p1.ADET);
            satısManager.Guncelle(p1);

            return RedirectToAction("Index");
        }

    }
}