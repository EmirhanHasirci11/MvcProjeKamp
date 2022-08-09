using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
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

        public void DraftToMessage(Draft d, Message m)
        {
            m.Subject = d.DraftSubject;
            m.MessageContent = d.DraftContent;
            m.MessageDate = d.DraftDate;
            m.SenderMail = "admin@gmail.com";
            m.ReceiverMail = d.ReceiverMail;
            m.MessageStatus = false;
            
        }

        public Message GetById(int id)
        {
            return _messageDal.GetByID(x => x.MessageID == id);
        }

        public List<Message> GetListInbox()
        {
            return _messageDal.List(x => x.ReceiverMail == "admin@gmail.com");
        }

        public List<Message> GetListSendbox()
        {
            return _messageDal.List(x => x.SenderMail == "admin@gmail.com");
        }

        public void MessageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MessageDelete(Message message)
        {
            _messageDal.Delete(message);
        }


        public void MessageReaded(int id)
        {
            var message = GetById(id);
            if (!message.MessageStatus)
            {
                message.MessageStatus = true;
            }
            else
            {
                message.MessageStatus = false;
            }
            MessageUpdate(message);
          
        }

        public void MessageUpdate(Message message)
        {
            _messageDal.Update(message);
        }

        public void SetReaded(int id)
        {
            var message = GetById(id);
            if (!message.MessageStatus)
            {
                message.MessageStatus = true;
            }
            MessageUpdate(message);
        }
    }
}
