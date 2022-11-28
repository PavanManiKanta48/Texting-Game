using Domain;
using Persistence;

namespace Service.Interface
{
    public interface IUserServices
    {
        List<TblUserDetail> GetUsers();
        bool CheckUserExist(string email);
        bool Register(Register register);
        string UserLogIn(UserLogin login);
        bool ForgetPassword(UserLogin changePwd);

    }
}
