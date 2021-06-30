using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;
        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }
        public void addWriter(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void DeleteWriter(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public Writer getByID(int id)
        {
            return _writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> getList()
        {
            return _writerDal.List();
        }

        public void UpdateWriter(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
