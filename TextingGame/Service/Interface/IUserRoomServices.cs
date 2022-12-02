using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserRoomServices
    {
        List<TblUserRoom> GetUsersRoom();
        bool AddUserToRoom(TblUserRoom addUser);
        bool CheckUserId(TblUserRoom checkuser);
        bool CheckRoomId(TblUserRoom checkRoom);
        bool CheckUserRoomId(TblUserRoom userRoom);
        bool DeleteUserFromRoom(TblUserRoom deleteUserRoom);
    }
}
