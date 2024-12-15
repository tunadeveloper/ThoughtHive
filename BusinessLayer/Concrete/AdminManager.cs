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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }


        public Admin GetAdmin(string username, string password)
        {
            return _adminDal.Get(x=>x.AdminUserName == username && x.AdminPassword == password);
            
        }

        public string GetRoleProvider(string username)
        {
            var admin = _adminDal.Get(x => x.AdminUserName == username);
            return admin != null ? admin.AdminRole : null;
        }
    }
}
