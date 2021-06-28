using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstracts
{
    public interface IRepository<T>
    {

        // CRUD -> Create - Read  - Update - Delete
        // Metodlar Tanımlanır

        List<T> List(); // List() -> Listele() 
        void Insert(T p);
        void Update(T p);
        void Delete(T p);

        List<T> List(Expression<Func<T, bool>> filter);


    }
}
