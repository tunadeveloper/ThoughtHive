﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
           return _headingDal.Get(x=>x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetListByWriterBL()
        {
          return _headingDal.List(x=>x.WriterID == 1);
        }

        public void HeadingActiveBL(Heading heading)
        {
            _headingDal.Update(heading);
        }

        public void HeadingAddBL(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public void HeadingPassiveBL(Heading heading)
        {
            _headingDal.Update(heading);
        }
        public void HeadingUpdateBL(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
