using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IWriterService
    {
        List<Writer> getList();
        void addWriter(Writer writer);
        Writer getByID(int id); // silmek ve guncellemek icin id getirecek
        void DeleteWriter(Writer writer);
        void UpdateWriter(Writer writer);
    }
}
