using Domain;
using Persistence.Model;

namespace Service.Interface
{
    public interface IUserServices
    {
        List<TblUser> GetUsers();
        bool CheckUserExist(string email);
        string Register(Register register);
        string UserLogIn(UserLogin login);
        bool ForgetPassword(UserLogin changePwd);

    }
}
