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
    public class DraftManager : IDraftService
    {
        IDraftDal _draftDal;

        public DraftManager(IDraftDal draftDal)
        {
            _draftDal = draftDal;
        }

        public void DraftAdd(Draft p)
        {
            _draftDal.Insert(p);
        }

        public void DraftDelete(Draft draft)
        {
            draft.DraftStatus = false;
            DraftUpdate(draft);
        }

        public void DraftUpdate(Draft draft)
        {
            _draftDal.Update(draft);
        }

        public Draft GetById(int id)
        {
            return _draftDal.GetByID(x => x.DraftID == id);
        }

        public List<Draft> GetList()
        {
            return _draftDal.List();
        }

        public List<Draft> GetListInDraft()
        {
            return _draftDal.List(x=>x.DraftStatus==true);
        }

        public void MessageToDraft(Message m, Draft d)
        {
            
            d.DraftSubject = m.Subject;
            d.DraftContent = m.MessageContent;
            d.DraftDate = m.MessageDate;
            d.SenderMail = "admin@gmail.com";
            d.ReceiverMail = m.ReceiverMail;
            d.DraftStatus = true;
            DraftAdd(d);
        }
    }
}
