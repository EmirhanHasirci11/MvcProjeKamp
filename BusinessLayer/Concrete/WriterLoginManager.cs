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
    public class WriterLoginManager : IWriterLoginService
    {
        IWriterDal _writerDal;
        Context c = new Context();
        public WriterLoginManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public int GetID(string p)
        {
            return c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
        }

        public Writer GetWriter(string username, string password)
        {
            return _writerDal.GetByID(x => x.WriterMail == username && x.WriterPassword == password);
        }
    }
}
