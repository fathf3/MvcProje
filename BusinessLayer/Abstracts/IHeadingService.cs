﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IHeadingService : IService<Heading>
    {
        List<Heading> GetListByWriter(int id);
    }
}
