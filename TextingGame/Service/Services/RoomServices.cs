using Domain.UserModel;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.Model;
using Service.Interface;
using Domain.RoomModel;

namespace Service.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly DbTextingGameContext _dbRoomContext;
        private readonly SendingSms sms;

        public RoomServices(DbTextingGameContext dbRoomContext)
        {
            _dbRoomContext = dbRoomContext;
            sms = new SendingSms();
        }

        //...........Fetch Data...........//
        public List<TblRoom> GetRoom()
        {
            var users = _dbRoomContext.TblRooms.ToList();
            return users;
        }

        //.........Check User Id Exist...........//
        //public bool CheckExistRoomName(TblRoom room)
        //{
        //    var room1 = _dbRoomContext.TblUsers.Where(x => x.UserId == room.RoomId).FirstOrDefault()!;
        //    if (room1 != null)
        //        return true;
        //    else
        //        return false;
        //}
       
        //...........Create Room..........//
        public BaseResponseModel CreateRoom(CreateRoomRequestModel createRoomRequestModel)
        {
            
            TblRoom room = new TblRoom()
            {
                RoomName = createRoomRequestModel.RoomName,
                NumOfPeopele = createRoomRequestModel.NoOfPeoples,
                IsActive = true,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                CreatedBy=2,
                UpdatedBy=1
            };
            _dbRoomContext.TblRooms.Add(room);
            try
            {
                _dbRoomContext.SaveChanges();
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    SuccessMessage = "Room created successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = string.Format("Creating an user failed. Exception details are: {0}", ex.Message)
                };
            }
            //room.CreatedDate = DateTime.Now;
            //room.UpdatedDate = DateTime.Now;
            //room.IsActive = true;
            //_dbRoomContext.TblRooms.Add(room);
            //_dbRoomContext.SaveChanges();
            //return room.RoomId;
        }

        // .........Check Room Id Exist............//
        public bool CheckExistRoomId(TblRoom room)
        {
            var room1 = _dbRoomContext.TblRooms.Where(x => x.RoomId == room.RoomId).FirstOrDefault();
            return room1 != null;

        }

        // ............Update Room.............//
        public bool UpdateRoom(TblRoom room)
        {
            TblRoom roomUpdate = _dbRoomContext.TblRooms.Where(x => x.RoomId == room.RoomId).FirstOrDefault()!;
            roomUpdate.RoomName = room.RoomName;
            roomUpdate.NumOfPeopele = room.NumOfPeopele;
            roomUpdate.UpdatedDate = DateTime.Now;
            roomUpdate.IsActive = true;
            _dbRoomContext.Entry(roomUpdate).State = EntityState.Modified;
            _dbRoomContext.SaveChanges();
            return true;
        }
        public string GenerateRoomCode(int Id)
        {
            TblRoom room = _dbRoomContext.TblRooms.Where(x => x.RoomId == Id).FirstOrDefault()!;
            return "RM-" + room.RoomName + "-" + room.RoomId;
        }

        //..............Sending Sms.............//
        public bool SendSms(double phone, string message)
        {
            sms.SendMessage(phone, message);
            return true;
        }
    }
}
