using Domain;
using Domain.UserModel;
using Persistence.Model;

namespace Service.Interface
{
    public interface IUserServices
    {
        List<TblUser> GetUsers();
        bool CheckUserExist(string email);
        BaseResponseModel Register(CreateUserRequestmodel register);
        string UserLogIn(UserLogin login);
        bool ForgetPassword(UserLogin changePwd);
        BaseResponseModel ValidateUserRequestModel(CreateUserRequestmodel createUserRequestmodel);

    }
}
