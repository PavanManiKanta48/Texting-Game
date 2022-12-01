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
        void AddUserToRoom(TblUserRoom addUser);
        bool CheckExistUserId(TblUserRoom checkUser);       
        void DeleteUserFromRoom(TblUserRoom deleteUser);
    }
}
