using Domain.RoomModel;
using Domain;
using Persistence.Model;

namespace Service.Interface
{
    public interface IRoomServices
    {
        List<TblRoom> GetRoom();
       // bool CheckExistUserId(TblRoom room);
        BaseResponseModel CreateRoom(CreateRoomRequestModel createRoomRequestModel);
        bool CheckExistRoomId(TblRoom room);
        bool UpdateRoom(TblRoom room);
        string GenerateRoomCode(int Id);
        bool SendSms(double phone, string message);
    }
}
