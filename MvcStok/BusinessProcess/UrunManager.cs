using MvcStok.Interfaces;
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.BusinessProcess
{
    public class UrunManager : IProcess<TBLURUNLER>
    {
        private MvcDbStokEntities db = DatabaseController.getSingleton().getDB();
        // private KategoriManager kategoriManager ;
        public void Ekle(TBLURUNLER obj)
        {
            //var ktgr = kategoriManager.Listeleme().Where(m => m.KATEGORIID == obj.TBLKATEGORILER.KATEGORIID).FirstOrDefault();

            //var ktgr = db.TBLKATEGORILER.ToList().Where(m => m.KATEGORIID == obj.URUNKATEGORI).FirstOrDefault();

            //obj.URUNKATEGORI = obj.TBLKATEGORILER.KATEGORIID;
            //obj.TBLKATEGORILER = ktgr;

            obj.isActive = true;
            db.TBLURUNLER.Add(obj);
            db.SaveChanges();
        }

        public void Guncelle(TBLURUNLER obj)
        {
            //var ktgr = db.TBLKATEGORILER.Where(m => m.KATEGORIID == obj.TBLKATEGORILER.KATEGORIID).FirstOrDefault();

            var urun = db.TBLURUNLER.Find(obj.URUNID);
            urun.URUNAD = obj.URUNAD;
            urun.MARKA = obj.MARKA;
            urun.STOK = obj.STOK;
            urun.FIYAT = obj.FIYAT;
            urun.URUNKATEGORI = obj.URUNKATEGORI;
            urun.isActive = obj.isActive;
            db.SaveChanges();
            
        }


        public void Sil(int id)
        {
            var urun = db.TBLURUNLER.Find(id); //Entityframework ORM Object Releated Mapping
            urun.isActive = false;
            db.SaveChanges();
        }

        public List<TBLURUNLER> Listeleme()
        {

            return db.TBLURUNLER.ToList();
        }

        public IQueryable<TBLURUNLER> SorguluListeleme()
        {
            throw new NotImplementedException();
        }

        public TBLURUNLER findById(int id)
        {
            return db.TBLURUNLER.Find(id);
        }

        public List<SelectListItem> ListByIsActive()
        {

            List<SelectListItem> degerler = (from i in db.TBLURUNLER.Where(m => m.isActive == true)
                                             select new SelectListItem
                                             {
                                                 Text = i.URUNAD,
                                                 Value = i.URUNID.ToString()
                                             }).ToList();
            return degerler;
        }


    }
}