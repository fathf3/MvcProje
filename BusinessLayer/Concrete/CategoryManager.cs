using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;// GenericRepository deki degerleri aliriz

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void addCategory(Category category)
        {
            _categoryDal.Insert(category);
        }

        public void DeleteCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public Category getByID(int id)
        {
            // Gelen id , sql deki id ye esitmi ?
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> getList()
        {
            return _categoryDal.List();
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
