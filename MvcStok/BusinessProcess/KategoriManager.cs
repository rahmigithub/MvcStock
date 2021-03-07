using MvcStok.Interfaces;
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.BusinessProcess
{
    public class KategoriManager : IProcess<TBLKATEGORILER>
    {
        private MvcDbStokEntities db = DatabaseController.getSingleton().getDB();
        public void Ekle(TBLKATEGORILER obj)
        {
            db.TBLKATEGORILER.Add(obj);
            obj.isActive = true;
            db.SaveChanges();
        }

      

        public void Guncelle(TBLKATEGORILER obj)
        {
            var ktgr = db.TBLKATEGORILER.Find(obj.KATEGORIID);
            ktgr.KATEGORIAD = obj.KATEGORIAD;
            ktgr.isActive = obj.isActive;
            db.SaveChanges();

        }

        public List<TBLKATEGORILER> Listeleme()
        {
            return db.TBLKATEGORILER.ToList();
        }

        public void Sil(int id)
        {
            var kategori = db.TBLKATEGORILER.Find(id);
            kategori.isActive = false;
            db.SaveChanges();
        }


        public TBLKATEGORILER findById(int id)
        {

            var ktgr = db.TBLKATEGORILER.Find(id);
            
            return ktgr;
        }

        public IQueryable<TBLKATEGORILER> SorguluListeleme()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> ListByIsActive() {

            List<SelectListItem> degerler = (from i in db.TBLKATEGORILER.Where(m => m.isActive == true)
                                             select new SelectListItem
                                             {
                                                 Text = i.KATEGORIAD,
                                                 Value = i.KATEGORIID.ToString()
                                             }).ToList();
            return degerler;
        }
    
    
    
    }
}