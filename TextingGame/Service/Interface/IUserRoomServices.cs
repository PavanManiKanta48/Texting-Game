using Domain;

namespace Service.Interface
{
    public interface IUserRoomServices
    {
        List<TblUserRoom> GetUsersRoom();
        bool AddUserToRoom(TblUserRoom addUser);
        bool CheckUserId(TblUserRoom checkuser);
        bool CheckRoomId(TblUserRoom checkRoom);
        bool CheckPersonId(TblUserRoom userRoom);
        bool DeleteUserFromRoom(TblUserRoom deleteUserRoom);
    }
}
