﻿using BusinessLayer.Abstracts;
using DataAccessLayer.Abstracts;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void add(Message p)
        {
            _messageDal.Insert(p);
        }

        public void Delete(Message p)
        {
            _messageDal.Delete(p);
        }

        public Message getByID(int id)
        {
            return _messageDal.Get(x => x.MessageID == id);
        }

        public List<Message> getList()
        {
            return _messageDal.List();
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReciverMail == "fatih@hotmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@hotmail.com");
        }

        public void Update(Message p)
        {
            _messageDal.Update(p);
        }
    }
}