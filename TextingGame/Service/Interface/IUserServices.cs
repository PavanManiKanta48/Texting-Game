using Domain;

namespace Service.Interface
{
    public interface IUserServices
    {
        List<TblUserDetail> GetUsers();
        bool CheckUserExist(string email);
        string Register(Register register);
        string UserLogIn(UserLogin login);
        bool ForgetPassword(UserLogin changePwd);

    }
}
