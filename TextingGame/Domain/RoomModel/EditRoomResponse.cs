﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.RoomModel
{
    public class EditRoomResponse:BaseResponseModel
    {
        public EditRoomRequestModel editRoomResponseModel { get; set; }
    }
}
