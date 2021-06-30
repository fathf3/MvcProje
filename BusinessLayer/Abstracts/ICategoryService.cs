using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface ICategoryService
    {

        List<Category> getList();
        void addCategory(Category category);
        Category getByID(int id); // silmek ve guncellemek icin id getirecek
        void DeleteCategory(Category category);
        void UpdateCategory(Category category);


    }
}
