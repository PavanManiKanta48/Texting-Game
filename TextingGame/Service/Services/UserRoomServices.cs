using Persistence;
using Service.Interface;

namespace Service.Services
{
    public class UserRoomServices : IUserRoomServices
    {
        private readonly DbTextingGameContext _dbUserRoomContext;

        public UserRoomServices(DbTextingGameContext dbContext)
        {
            _dbUserRoomContext = dbContext;
        }

        //.................Get User Room..................//
        public List<TblUserRoom> GetUsersRoom()
        {
            var usersinroom = _dbUserRoomContext.TblUserRooms.ToList();
            return usersinroom;
        }

        //public List<TblRoom> Room(TblUserRoom user)
        //{
        //    //var room = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == user.RoomId).ToList()!;
        //    var room = _dbUserRoomContext.TblRooms.Where(r => r.Equals(user)).ToList();
        //    return room;
        //}

        public bool CheckUserId(TblUserRoom checkUser)
        {
            var checkMessageUserId = _dbUserRoomContext.TblUserDetails.Where(r => r.UserId == checkUser.UserId).FirstOrDefault();
            if (checkMessageUserId != null)
                return true;
            else
                return false;
        }

        //............Check Room Id ..................//
        public bool CheckRoomId(TblUserRoom checkRoom)
        {
            var checkMessageRoomId = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == checkRoom.RoomId).FirstOrDefault();
            if (checkMessageRoomId != null)
                return true;
            else
                return false;
        }

        //..........Add User Room...................//
        public bool AddUserToRoom(TblUserRoom addUser)
        {
            TblRoom room = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == addUser.RoomId).FirstOrDefault()!;
            List<TblUserRoom> userRooms = _dbUserRoomContext.TblUserRooms.Where(r => r.RoomId == addUser.RoomId).ToList()!;
            if (userRooms.Count <= room.NumOfPeopele)
            {
                addUser.CreatedDate = DateTime.Now;
                addUser.IsActive = true;
                _dbUserRoomContext.TblUserRooms.Add(addUser);
                _dbUserRoomContext.SaveChanges();
                return true;

            }
            else
            {
                return false;

            }
        }

        // ..............Check User Room Id..............//
        public bool CheckUserRoomId(TblUserRoom userRoom)
        {
            var checkuserRoomId = _dbUserRoomContext.TblUserRooms.Where(x => x.PersonId == userRoom.PersonId).FirstOrDefault()!;
            if (checkuserRoomId != null)
                return true;
            else
                return false;
        }

        //................Delete User Room................//
        public bool DeleteUserFromRoom(TblUserRoom deleteUserRoom)
        {
            var deleteFromRoom = _dbUserRoomContext.TblUserRooms.Where(x => x.PersonId == deleteUserRoom.PersonId).FirstOrDefault()!;
            _dbUserRoomContext.TblUserRooms.Remove(deleteFromRoom);
            _dbUserRoomContext.SaveChanges();
            return true;
        }
    }
}
