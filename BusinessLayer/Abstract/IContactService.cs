using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetListBL();
        void AddContactBL(Contact contact);   
        void DeleteContactBL(Contact contact);
        void UpdateContactBL(Contact contact);  
        Contact GetByIDBL(int id);
    }
}
