using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IService<T>
    {
        List<T> getList();
        void add(T p);
        T getByID(int id); // silmek ve guncellemek icin id getirecek
        void Delete(T p);
        void Update(T p);
    }
}
