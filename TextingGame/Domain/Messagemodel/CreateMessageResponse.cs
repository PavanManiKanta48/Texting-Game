using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messagemodel
{
    public class CreateMessageResponse:BaseResponseModel
    {
        public CreateUserRoomRequestModel createUserRoomResponse { get; set; }
    }
}
