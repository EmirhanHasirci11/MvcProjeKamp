using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
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
        Context c = new Context();

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

        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail ==p );
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public int GetUnreadMessage(string p)
        {
            return c.Messages.Where(x => x.MessageStatus == false && x.ReceiverMail==p).Count();
        }

        public void MessageAdd(Message message, string mail)
        {
            message.SenderMail = mail;
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
