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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void add(Contact p)
        {
            _contactDal.Insert(p);
        }

        public void Delete(Contact p)
        {
            _contactDal.Delete(p);
        }

        public Contact getByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> getList()
        {
            return _contactDal.List();
        }

        public void Update(Contact p)
        {
            _contactDal.Update(p);
        }
    }
}
