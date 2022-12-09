using Domain.UserModel;
using Domain;
using Persistence.Model;
using Domain.UserRoomModel;

namespace Service.Interface
{
    public interface IUserRoomServices
    {
        List<ListUserRoomResponse> GetUsersRoom(int roomId);
        //bool AddUserToRoom(TblUserRoom addUser);
        bool CheckUserId(int[]? checkUser);
        bool CheckRoomId(int? checkroom);
        BaseResponseModel DeleteUserFromRoom(DeleteRoomRequsetModel deleteRoomRequsetModel);
        BaseResponseModel ValidateUserRequestModel(DeleteRoomRequsetModel deleteRoomRequsetModel);
        BaseResponseModel ValidateUserRequestModel(CreateUserRoomRequestModel createUserRoomRequestModel);
        BaseResponseModel AddUserToRoom(CreateUserRoomRequestModel createUserRoomRequestModel);
    }
}
