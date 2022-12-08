using Domain.RoomModel;
using Domain;
using Persistence.Model;

namespace Service.Interface
{
    public interface IRoomServices
    {
        List<RoomResponse> GetRoom(int userId);
        BaseResponseModel ValidateUserRequestModel(CreateRoomRequestModel createRoomRequestModel);
        bool CheckExistRoomName(string room);
        BaseResponseModel CreateRoom(CreateRoomRequestModel createRoomRequestModel);
        bool CheckExistRoomId(TblRoom room);
        bool UpdateRoom(TblRoom room);
        string GenerateRoomCode(int Id);
        bool SendSms(double phone, string message);
    }
}
