using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        void MessageAdd(Message message,string mail);
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        Message GetById(int id);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        void MessageReaded(int id);
        void SetReaded(int id);
        void DraftToMessage(Draft d,Message m);
        int GetUnreadMessage(string p);
    }
}
