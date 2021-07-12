using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;
        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        

        public void add(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void Delete(Heading heading)
        {
            
            _headingDal.Update(heading);
        }

        public Heading getByID(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> getList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriter()
        {
            return _headingDal.List(x => x.WriterID == 1);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
