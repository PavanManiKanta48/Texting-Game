﻿using Persistence.Model;
using Service.Interface;

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
        public List<TblMessage> GetMessages(int RoomId)
        {
            var UserMessage = _dbMessageContext.TblMessages.Where(x => x.RoomId == RoomId).ToList();
            return UserMessage;

        }

        //............Check User Id................//
        public bool CheckUserId(TblMessage message)
        {
            var checkMessageUserId = _dbMessageContext.TblUsers.Where(r => r.UserId == message.UserId).FirstOrDefault();
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
        public bool AddMessages(string Message, int RoomID, int UserId)
        {
            TblMessage message = new TblMessage();
            message.Message = Message;
            message.RoomId = RoomID;
            message.UserId = UserId;
            message.CreatedDate = DateTime.Now;
            message.UpdatedDate = DateTime.Now;
            message.IsActive = true;
            _dbMessageContext.TblMessages.Add(message);
            _dbMessageContext.SaveChanges();
            return true;
        }
    }
}
