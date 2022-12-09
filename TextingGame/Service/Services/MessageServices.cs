using Domain;
using Domain.Messagemodel;
using Persistence.Model;
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
        public List<MessageResponse> GetRoom(int Roomid)
        {
            List<MessageResponse> userRooms = (from msgRoom in _dbMessageContext.TblMessages
                                               join users in _dbMessageContext.TblUsers on msgRoom.UserId equals users.UserId
                                               join rooms in _dbMessageContext.TblRooms on msgRoom.RoomId equals rooms.RoomId
                                               where msgRoom.RoomId == Roomid
                                               select new MessageResponse()
                                               {
                                                   Timestamp = msgRoom.CreatedDate,
                                                   FirstName = users.UserName,
                                                   Message = msgRoom.Message
                                               }).ToList();
            if (userRooms.Any())
            {
                return userRooms;
            }
            return new List<MessageResponse>();
        }

        //............Check User Id................//
        public bool CheckUserId(int userId)
        {
            var checkMessageUserId = _dbMessageContext.TblUsers.Where(r => r.UserId == userId).FirstOrDefault();
            if (checkMessageUserId != null)
                return true;
            else
                return false;
        }

        //............Check Room Id ..................//

        public bool CheckRoomId(int roomId)
        {
            var checkMessageRoomId = _dbMessageContext.TblRooms.Where(r => r.RoomId == roomId).FirstOrDefault();
            if (checkMessageRoomId != null)
                return true;
            else
                return false;
        }

        //..................User Add Message...................//
        public BaseResponseModel AddMessages(int RoomID, string Message, int UserId)
        {
            TblMessage message = new TblMessage()
            {
                Message = Message,
                UserId = UserId,
                RoomId = RoomID,
                CreatedDate = DateTime.Now,
                CreatedBy = 2,
                UpdatedBy = 2,
                UpdatedDate = DateTime.Now,
                IsActive = true
            };
            _dbMessageContext.TblMessages.Add(message);
            try
            {
                _dbMessageContext.SaveChanges();
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    SuccessMessage = "Message send successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = string.Format("Sending Message to user failed. Exception details are: {0}", ex.Message)
                };
            }
        }
    }
}
