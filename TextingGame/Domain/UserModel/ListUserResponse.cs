using Domain.UserModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GetUserModel
{
    public class ListUserResponse:BaseResponseModel
    {
        public List<EditUserRequestModel> editUserRequestModels { get; set; }
    }
}
