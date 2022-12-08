namespace Domain.Messagemodel
{
    public class CreateUserRoomRequestModel
    {
        public int? RoomId { get; set; }
        public string Message { get; set; } = null!;
    }
}
