using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInboxBL();
        List<Message> GetListSendboxBL();
        void MessageDeleteBL(Message message); 
        void MessageUpdateBL(Message message);    
        void MessageAddBL(Message message);
        Message GetByIDBL(int id);
    }
}
