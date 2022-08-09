using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IDraftService
    {
        void DraftAdd(Draft p);
        void MessageToDraft(Message m, Draft d);
        List<Draft> GetList();
        Draft GetById(int id);
        void DraftDelete(Draft draft);
        void DraftUpdate(Draft draft);
        List<Draft> GetListInDraft();

    }
}
