namespace Domain.UserModel
{
    public class EditUserForgotPasswordResponse : BaseResponseModel
    {
        public UserForgotPasswordRequestModel UserForgotPasswordRequest { get; set; }
    }
}
