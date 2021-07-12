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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void add(Content content)
        {
            _contentDal.Insert(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public Content getByID(int id)
        {
            return _contentDal.Get(x => x.ContentID == id);
        }

        public List<Content> getList()
        {
            return _contentDal.List();
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }

        public List<Content> getListByHeadingId(int id)
        {
            return _contentDal.List(x => x.HeadingID == id);
        }

        public List<Content> getListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }
    }
}
