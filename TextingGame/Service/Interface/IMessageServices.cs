using Persistence.Model;

namespace Service.Interface
{
    public interface IMessageServices
    {
        List<TblMessage> GetMessages(int RoomId);
        bool CheckUserId(TblMessage message);
        bool CheckRoomId(TblMessage message);
        bool AddMessages(string Message, int RoomId, int UserId);
    }
}
