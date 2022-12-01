using Persistence;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserRoomServices:IUserRoomServices
    {
        private readonly DbTextingGameContext _dbContext;
        public UserRoomServices(DbTextingGameContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TblUserRoom> GetUsersRoom()
        {
            var usersinroom = _dbContext.TblUserRooms.ToList();
            return usersinroom;
        }
        public void AddUserToRoom(TblUserRoom addUser)
        {
            var checkroom = _dbContext.TblRooms.Where(r => r.RoomId == addUser.RoomIdFk).FirstOrDefault();
            //int count = 0;
            var noofusers = checkroom.NumOfPeopele;
            if (checkroom != null)
            {
                if (noofusers!=0)
                {
                    addUser.EnterDate = DateTime.Now;
                    addUser.IsActive = true;
                    _dbContext.TblUserRooms.Add(addUser);
                     noofusers--;
                    //_dbContext.TblRooms.Update();
                    _dbContext.SaveChanges();
                }
            }
               
        }
        public bool CheckExistUserId(TblUserRoom checkUser)
        {
            var checkId = _dbContext.TblUserDetails.Where(x => x.UserId == checkUser.UserId).FirstOrDefault()!;
            if (checkId != null)
                return true;
            else
                return false;
        }
        
        public void DeleteUserFromRoom(TblUserRoom deleteUser)
        {
            var deleteFromRoom = _dbContext.TblUserRooms.Where(x => x.UserId == deleteUser.UserId).FirstOrDefault()!;
            _dbContext.TblUserRooms.Remove(deleteFromRoom);
            _dbContext.SaveChanges();
        }
    }
}
