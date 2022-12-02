using Persistence;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
   public class MessageServices : IMessageServices
    {
        private readonly DbTextingGameContext _dbMessageContext;

        public MessageServices(DbTextingGameContext dbMessageContext)
        {
            _dbMessageContext = dbMessageContext;
        }

        //...........Get User Message...........//
        public List<TblMessage> GetMessages()
        {
            var UserMessage = _dbMessageContext.TblMessages.ToList();
            return UserMessage;
        }

        //............Check User Id................//
        public bool CheckUserId(TblMessage message)
        {
            var checkMessageUserId = _dbMessageContext.TblUserDetails.Where(r => r.UserId == message.UserId ).FirstOrDefault();
            if (checkMessageUserId != null)
                return true;
            else
                return false;
        }

        //............Check Room Id ..................//
        public bool CheckRoomId(TblMessage message)
        {
            var checkMessageRoomId = _dbMessageContext.TblRooms.Where(r => r.RoomId == message.RoomId).FirstOrDefault();
            if (checkMessageRoomId != null)
                return true;
            else
                return false;
        }

        //..................User Add Message...................//
        public bool AddMessages(TblMessage message)
        {
            message.CreatedDate = DateTime.Now;
            message.UpdatedDate = null;
            message.IsActive = true;
            _dbMessageContext.TblMessages.Add(message);
            _dbMessageContext.SaveChanges();
            return true;
        }
    }
}
