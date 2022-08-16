using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IContentService
    {
        void ContentAdd(Content content);
        List<Content> GetList(string p);
        List<Content> GetList();
        Content GetById(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
        List<Content> GetListById(int id);
        List<Content> GetListByWriter(int id);
        List<Content> GetListByHeading(int id);
        int CountOfContentByHeadingId(int id);
    }
}
