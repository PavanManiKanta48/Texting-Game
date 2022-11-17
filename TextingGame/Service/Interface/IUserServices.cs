using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
   public interface IUserServices
    {
        List<TblUserDetail> GetUsers();
        bool CheckUserExist(string email);
        void Register(Register register);
        bool UserLogIn(UserLogin login);
        CrudStatus ForgetPassword(Register changePwd);
    }
}
