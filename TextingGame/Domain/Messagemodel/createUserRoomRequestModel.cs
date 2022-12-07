using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Messagemodel
{
    public class createUserRoomRequestModel
    {
        public int? RoomId { get; set; }
        public string Message { get; set; } = null!;
    }
}
