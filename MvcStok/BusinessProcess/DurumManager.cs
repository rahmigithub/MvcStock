using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcStok.BusinessProcess
{


    public class DurumManager
    {
        private MvcDbStokEntities db = DatabaseController.getSingleton().getDB();


        public TBLSATISDURUM findById(int id) {


            return db.TBLSATISDURUMs.Find(id);
        }

        public List<TBLSATISDURUM> Listeleme() {


            return db.TBLSATISDURUMs.ToList();
        }


        public List<SelectListItem> ListelemeSelectedListItem() {

            List<SelectListItem> degerler = (from i in db.TBLSATISDURUMs
                                             select new SelectListItem
                                             {
                                                 Text = i.SATISDURUMAD,
                                                 Value = i.SATISDURUMAD
                                             }).ToList();



            return degerler;
        }
    }
}