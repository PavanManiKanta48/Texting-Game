using Domain;
using Persistence;

namespace Service.Interface
{
    public interface IUserServices
    {
        List<TblUserDetail> GetUsers();
        bool CheckUserExist(string email);
        void Register(Register register);
        string UserLogIn(UserLogin login);
        void ForgetPassword(UserLogin changePwd);
    }
}
