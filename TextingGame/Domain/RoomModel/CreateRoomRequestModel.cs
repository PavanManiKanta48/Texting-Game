﻿namespace Domain.RoomModel
{
    public class CreateRoomRequestModel
    {
        public string RoomName { get; set; } = null!;
        public int NoOfPeoples { get; set; }
    }
}
