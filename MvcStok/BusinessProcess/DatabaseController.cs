using MvcStok.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcStok.BusinessProcess
{
    public class DatabaseController
    {
        private MvcDbStokEntities db;

        private static DatabaseController singleton;
        public static DatabaseController getSingleton()
        {
            if (singleton == null)
                singleton = new DatabaseController();

            return singleton;
        }

        private DatabaseController()
        {

        }

        public MvcDbStokEntities getDB()
        {
            if (db == null)
                db = new MvcDbStokEntities();

            return db;
        }
    }
}