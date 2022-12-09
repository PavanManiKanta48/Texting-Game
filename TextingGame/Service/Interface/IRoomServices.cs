using Domain;
using Domain.RoomModel;
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
        BaseResponseModel UpdateRoom(EditRoomRequestModel editRoomRequestModel);
        string GenerateRoomCode(int Id);
        BaseResponseModel SendSms(double phone, string message);
    }
}
