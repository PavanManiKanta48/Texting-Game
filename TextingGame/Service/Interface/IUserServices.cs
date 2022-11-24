using Domain;
using Persistence;

namespace Service.Interface
{
    public interface IUserServices
    {
        List<TblUserDetail> GetUsers();
        bool CheckUserExist(string email);
        void Register(Register register);
        bool UserLogIn(UserLogin login);
        void ForgetPassword(UserLogin changePwd);
    }
}
