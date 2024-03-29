﻿using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IWriterService
    {
        List<Writer> GetList();
        void WriterAdd(Writer p);
        void WriterDelete(Writer p);
        void WriterUpdate(Writer p);
        Writer GetByID(int id);
    }
}
