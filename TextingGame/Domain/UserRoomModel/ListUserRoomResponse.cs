using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserRoomModel
{
    public class ListUserRoomResponse:BaseResponseModel
    {
        public List<ListUserRoomRequestModel> listUserRoomRequestModels { get; set; }
    }
}
