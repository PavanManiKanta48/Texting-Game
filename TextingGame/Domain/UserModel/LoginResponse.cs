namespace Domain.UserModel
{
    public class UserLoginResponse : BaseResponseModel
    {
        public LoginUserRequestModel LoginUserRequest { get; set; }
    }
}
