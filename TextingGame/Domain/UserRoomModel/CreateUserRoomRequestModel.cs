using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserRoomModel
{
    public class CreateUserRoomRequestModel
    {
        public int? RoomId { get; set; }
        public int? UserId { get; set; }
    }
}
