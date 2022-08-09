using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ISkillsService
    {

        List<Skill> GetList();
        List<Skill> GetListAll();
        void SkillAdd(Skill skill);
        Skill GetById(int id);
        void SkillDelete(Skill skill);
        void SkillUpdate(Skill skill);
    }
}
