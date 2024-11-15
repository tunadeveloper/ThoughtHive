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
        List<Writer> GetListBL();
        void WriterAddBL(Writer writer);
        void WriterDeleteBL(Writer writer);
        void WriterUpdateBL(Writer writer);
        Writer GetByIDBL(int id);
    }
}
