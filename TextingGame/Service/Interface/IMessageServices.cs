using Persistence;

namespace Service.Interface
{
    public interface IMessageServices
    {
        List<TblMessage> GetMessages();
        bool CheckUserId(TblMessage message);
        bool CheckRoomId(TblMessage message);
        bool AddMessages(TblMessage message);
    }
}
