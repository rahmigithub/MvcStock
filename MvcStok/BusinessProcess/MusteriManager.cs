using MvcStok.Interfaces;
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.BusinessProcess
{
    public class MusteriManager : IProcess<TBLMUSTERILER>
    {

        private MvcDbStokEntities db = DatabaseController.getSingleton().getDB();
        public void Ekle(TBLMUSTERILER obj)
        {
            obj.isActive = true;
            db.TBLMUSTERILER.Add(obj);
            db.SaveChanges();

        }

        public TBLMUSTERILER findById(int id)
        {
            return db.TBLMUSTERILER.Find(id);
        }

        public void Guncelle(TBLMUSTERILER obj)
        {

            var mus = db.TBLMUSTERILER.Find(obj.MUSTERIID);
            mus.MUSTERIAD = obj.MUSTERIAD;
            mus.MUSTERISOYAD = obj.MUSTERISOYAD;
            mus.isActive = obj.isActive;
            db.SaveChanges();
        }

        public List<TBLMUSTERILER> Listeleme()
        {
            return db.TBLMUSTERILER.ToList();
        }

        public void Sil(int id)
        {
            var musteri = db.TBLMUSTERILER.Find(id);
            musteri.isActive = false;
            db.SaveChanges();
        }

        public IQueryable<TBLMUSTERILER> SorguluListeleme()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> ListByIsActive()
        {

            List<SelectListItem> degerler = (from i in db.TBLMUSTERILER.Where(m => m.isActive == true)
                                             select new SelectListItem
                                             {
                                                 Text = i.MUSTERIAD+" "+i.MUSTERISOYAD,
                                                 Value = i.MUSTERIID.ToString()
                                             }).ToList();
            return degerler;
        }
    }
}