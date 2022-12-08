namespace Domain.UserRoomModel
{
    public class ListUserRoomResponse : BaseResponseModel
    {
        public List<ListUserRoomRequestModel> listUserRoomRequestModels { get; set; }
    }
}
