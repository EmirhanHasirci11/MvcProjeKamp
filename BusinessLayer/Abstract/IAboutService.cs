using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAboutService
    {
        void AboutAdd(About about);
        List<About> GetList();
        About GetById(int id);
        void AboutDelete(About about);
        void AboutUpdate(About about);
        
    }
}
