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
    public class AboutManager : IAboutService
    {

        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void add(About p)
        {
            _aboutDal.Insert(p);
        }

        public void Delete(About p)
        {
            _aboutDal.Delete(p);
        }

        public About getByID(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id);
        }

        public List<About> getList()
        {
            return _aboutDal.List();
        }

        public void Update(About p)
        {
            _aboutDal.Update(p);
        }
    }
}
