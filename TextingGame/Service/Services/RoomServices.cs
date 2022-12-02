using Persistence;
using Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace Service.Services
{
    public class RoomServices : IRoomServices
    {
        private readonly DbTextingGameContext _dbRoomContext;

        public RoomServices(DbTextingGameContext dbRoomContext)
        {
            _dbRoomContext = dbRoomContext;
        }

        //...........Fetch Data...........//
        public List<TblRoom> GetRoom()
        {
            var users = _dbRoomContext.TblRooms.ToList();
            return users;
        }

        //.........Check User Id Exist...........//
        public bool CheckExistUserId(TblRoom room)
        
        {
            var room1 = _dbRoomContext.TblUserDetails.Where(x => x.UserId == room.UserId).FirstOrDefault()!;
            if (room1 != null)
                return true;
            else
                return false;
        }

        //...........Create Room..........//
        public int CreateRoom(TblRoom room)

        {
            room.CreatedDate = DateTime.Now;
           room.UpdatedDate = null;
            room.IsActive = true;
            _dbRoomContext.TblRooms.Add(room);
            _dbRoomContext.SaveChanges();
            return room.RoomId;
        }

       // .........Check Room Id Exist............//
        public bool CheckExistRoomId(TblRoom room)
        {
            var room1 = _dbRoomContext.TblRooms.Where(x => x.RoomId == room.RoomId).FirstOrDefault();
            return room1 != null;

        }

        // ............Update Room.............//
        public void UpdateRoom(TblRoom room)
        {
            TblRoom roomUpdate = _dbRoomContext.TblRooms.Where(x => x.RoomId == room.RoomId).FirstOrDefault()!;
            roomUpdate.RoomName = room.RoomName;
            roomUpdate.NumOfPeopele = room.NumOfPeopele;
            roomUpdate.UpdatedDate = DateTime.Now;
            roomUpdate.IsActive = true;
            _dbRoomContext.Entry(roomUpdate).State = EntityState.Modified;
                _dbRoomContext.SaveChanges();
        }

     public string GenerateRoomCode(int Id)
        {
            TblRoom room = _dbRoomContext.TblRooms.Where(x => x.RoomId == Id).FirstOrDefault()!;
            return "RM-" + room.RoomName + "-" + room.RoomId;
        }
    }
}
