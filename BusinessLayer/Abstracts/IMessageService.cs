using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstracts
{
    public interface IMessageService : IService<Message>
    {
        List<Message> GetListInbox();
        List<Message> GetListSendbox();


    }
}
