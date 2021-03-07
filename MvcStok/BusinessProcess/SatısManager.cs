using MvcStok.Interfaces;
using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcStok.BusinessProcess
{
    public class SatısManager : IProcess<TBLSATISLAR>
    {

        private MvcDbStokEntities db = DatabaseController.getSingleton().getDB();

        public void Ekle(TBLSATISLAR obj)
        {
            var satıs = new TBLSATISLAR();
            db.TBLSATISLARs.Add(obj);
            db.SaveChanges();
        }

        public TBLSATISLAR findById(int id)
        {
            var satıs = db.TBLSATISLARs.Find(id);

            return satıs;
        }

        public void Guncelle(TBLSATISLAR obj)
        {
            var satıs = db.TBLSATISLARs.Find(obj.SATISID);
            satıs.SATISID = obj.SATISID;
            satıs.URUN = obj.URUN;
            satıs.MUSTERI = obj.MUSTERI;
            satıs.ADET = obj.ADET;
            satıs.FIYAT = obj.FIYAT;
            satıs.DURUM = obj.DURUM;
            db.SaveChanges();
        }

        public List<TBLSATISLAR> Listeleme()
        {
            return db.TBLSATISLARs.ToList();
        }

        public void Sil(int id)
        {
            db.TBLSATISLARs.Remove(db.TBLSATISLARs.Find(id));
            db.SaveChanges();
        }

        public IQueryable<TBLSATISLAR> SorguluListeleme()
        {
            throw new NotImplementedException();
        }
    }
}