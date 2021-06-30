using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IHeadingService
    {
        List<Heading> getList();
        void addHeading(Heading heading);
        Heading getByID(int id);
        void DeleteHeading(Heading heading);
        void UpdateHeading(Heading heading);
    }
}
