using Domain.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GetUserModel
{
    public class EditUserResponse:BaseResponseModel
    {
        public EditUserRequestModel EditUserRequestModel { get; set; }
    }
}
