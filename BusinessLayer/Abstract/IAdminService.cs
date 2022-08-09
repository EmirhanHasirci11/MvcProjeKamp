using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        bool AdminEncryption(Admin inputValue, Admin dbValue);
        void AdminAdd(Admin p);
        Admin getByUsername(string username);
        void AdminHasher(Admin p,string salt);
        void AdminUpdate(Admin admin);
        string AdminGenerateSalt();
        Admin AdminUsername(Admin p);
    }
}
