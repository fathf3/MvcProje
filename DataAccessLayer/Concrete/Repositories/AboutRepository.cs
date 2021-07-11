using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class AboutRepository : IAboutDal
    {
        public void Delete(About p)
        {
            throw new NotImplementedException();
        }

        public About Get(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Insert(About p)
        {
            throw new NotImplementedException();
        }

        public List<About> List()
        {
            throw new NotImplementedException();
        }

        public List<About> List(Expression<Func<About, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(About p)
        {
            throw new NotImplementedException();
        }
    }
}
