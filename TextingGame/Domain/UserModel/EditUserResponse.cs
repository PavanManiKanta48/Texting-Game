using Domain.UserModel;

namespace Domain.GetUserModel
{
    public class EditUserResponse : BaseResponseModel
    {
        public EditUserRequestModel EditUserRequestModel { get; set; }
    }
}
