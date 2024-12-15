using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetList();
        void HeadingAddBL(Heading heading);
        void HeadingPassiveBL(Heading heading);
        void HeadingActiveBL(Heading heading);
        void HeadingUpdateBL(Heading heading);
        Heading GetByID(int id);

        List<Heading> GetListByWriterBL();
    }
}
