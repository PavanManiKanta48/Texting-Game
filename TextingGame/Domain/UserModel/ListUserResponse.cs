using Domain.UserModel;

namespace Domain.GetUserModel
{
    public class ListUserResponse : BaseResponseModel
    {
        public List<EditUserRequestModel> editUserRequestModels { get; set; }
    }
}
