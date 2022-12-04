using Persistence;

namespace Service.Interface
{
    public interface IRoomServices
    {
        List<TblRoom> GetRoom();
        bool CheckExistUserId(TblRoom room);
        int CreateRoom(TblRoom room);
        bool CheckExistRoomId(TblRoom room);
        void UpdateRoom(TblRoom room);
        string GenerateRoomCode(int Id);
        bool SendSms(double phone, string message);
    }
}
