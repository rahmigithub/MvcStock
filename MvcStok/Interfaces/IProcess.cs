using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcStok.Interfaces
{
    public interface IProcess<T>
    {
        void Ekle(T obj);
        void Guncelle(T obj);

        void Sil(int id);
        
        List<T> Listeleme();

        T findById(int id);

        IQueryable<T> SorguluListeleme();
    }
}
