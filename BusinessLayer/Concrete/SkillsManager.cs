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
    public class SkillsManager : ISkillsService
    {
        ISkillDal _skillDal;

        public SkillsManager(ISkillDal skillDal)
        {
            _skillDal = skillDal;
        }

        public Skill GetById(int id)
        {
            return _skillDal.GetByID(x => x.SkillID == id);
        }

        public List<Skill> GetList()
        {
            return _skillDal.List(x=>x.SkillStatus==true);
        }

        public List<Skill> GetListAll()
        {
            return _skillDal.List();
        }

        public List<Skill> GetListAllPercentage()
        {
            return _skillDal.List();
        }

        public void SkillAdd(Skill skill)
        {
            _skillDal.Insert(skill);
        }

        public void SkillDelete(Skill skill)
        {
            if (skill.SkillStatus == true)
            {
                skill.SkillStatus = false;
            }
            else
            {
                skill.SkillStatus = true;
            }
            SkillUpdate(skill);
            
        }

        public void SkillUpdate(Skill skill)
        {
            _skillDal.Update(skill);
        }
    }
}
