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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByIDBL(int id)
        {
            throw new NotImplementedException();
        }

        public List<Message> GetListBL()
        {
            return _messageDal.List(x=>x.ReceiverMail == "admin@gmail.com");
        }

        public void MessageAddBL(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageDeleteBL(Message message)
        {
            throw new NotImplementedException();
        }

        public void MessageUpdateBL(Message message)
        {
            throw new NotImplementedException();
        }
    }
}
