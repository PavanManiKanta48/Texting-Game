using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserModel
{
    public class EditUserForgotPasswordResponse : BaseResponseModel
    {
        public UserForgotPasswordRequestModel UserForgotPasswordRequest { get; set; }
    }
}
