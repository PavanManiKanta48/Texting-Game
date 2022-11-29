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
        private readonly DbTextingGameContext _dbContext;
        public RoomServices(DbTextingGameContext dbContext)
        {
            _dbContext = dbContext;
        }
        //...........Fetch Data...........//
        public List<TblRoom> GetRoom()
        {
            var users = _dbContext.TblRooms.ToList();
            return users;
        }
        //.........Check User Id Exist...........//
        public bool CheckExistUserId(TblRoom room)
        
        {
            var room1 = _dbContext.TblUserDetails.Where(x => x.UserId == room.UserId).FirstOrDefault()!;
            if (room1 != null)
                return true;
            else
                return false;
        }

        //...........Create Room..........//
        public int CreateRoom(TblRoom croom)

        {
            croom.CheckIn = DateTime.Now;
            croom.Updated = null;
            _dbContext.TblRooms.Add(croom);
            _dbContext.SaveChanges();
            return croom.RoomId;
        }

       // .........Check Room Id Exist............//
        public bool CheckExistRoomId(TblRoom room)
        {
            var room1 = _dbContext.TblRooms.Where(x => x.RoomId == room.RoomId).FirstOrDefault();
            return room1 != null;

        }
        // ............Update Room.............//
        public void UpdateRoom(TblRoom uroom)
        {
            TblRoom room = _dbContext.TblRooms.Where(x => x.RoomId == uroom.RoomId).FirstOrDefault()!;
                room.RoomName = uroom.RoomName;
                room.NumOfPeopele = uroom.NumOfPeopele;
                room.Updated = DateTime.Now;
                _dbContext.Entry(room).State = EntityState.Modified;
                _dbContext.SaveChanges();
        }

        //...........Delete Room................//
        public void DeleteRoom(TblRoom droom)
        {
            TblRoom user = _dbContext.TblRooms.Where(x => x.RoomId == droom.RoomId).FirstOrDefault()!;
            _dbContext.TblRooms.Remove(user);
            _dbContext.SaveChanges();
        }

        public string GenerateRoomCode(int Id)
        {
            TblRoom room = _dbContext.TblRooms.Where(x => x.RoomId == Id).FirstOrDefault()!;
            return "RM-" + room.RoomName + "-" + room.RoomId;
        }
    }
}
