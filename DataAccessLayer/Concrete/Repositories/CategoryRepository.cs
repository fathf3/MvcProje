using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class CategoryRepository : ICategoryDal
    {

        Context context = new Context();
        DbSet<Category> _objet;

        public void Delete(Category category)
        {
            throw new NotImplementedException();
        }

        public void Insert(Category category)
        {
            throw new NotImplementedException();
        }

        public List<Category> List()
        {
            throw new NotImplementedException();
        }

        public List<Category> List(Expression<Func<Category, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public void Update(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
