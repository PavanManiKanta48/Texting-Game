using Domain;
using Domain.RoomModel;
using Microsoft.AspNetCore.Mvc;
using Persistence.Model;
using Service.Interface;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly DbTextingGameContext _dbRoomcontext;
        private readonly IRoomServices _roomServices;
        private readonly ISendingSms _sendingSms;

        public RoomController(DbTextingGameContext dbContext, IRoomServices roomServices, ISendingSms sendingSms)
        {
            _dbRoomcontext = dbContext;
            _roomServices = roomServices;
            _sendingSms = sendingSms;
        }

        // GET: api/<RoomController>
        // [Authorize]
        [HttpGet]
        public List<RoomResponse> GetRoom(int userId)
        {
            try
            {
                //Validation
                return userId == 0 ? new List<RoomResponse>() : _roomServices.GetRoom(userId);
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        [HttpPost]
        public BaseResponseModel CreateRoom(CreateRoomRequestModel createRoomRequestModel)
        {
            try
            {
                //BaseResponseModel errorModel = _roomServices.ValidateUserRequestModel(createRoomRequestModel);
                //if (errorModel.StatusCode == System.Net.HttpStatusCode.BadRequest)
                //{
                //    return errorModel;
                //}
                return _roomServices.CreateRoom(createRoomRequestModel);

            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        [HttpPut]
        public BaseResponseModel UpdateRoom(EditRoomRequestModel editRoomRequestModel)
        {
            try
            {
                return _roomServices.UpdateRoom(editRoomRequestModel);
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
        //[Authorize]
        [HttpPost("send message")]
        public BaseResponseModel SendingSms(double phone, string message)
        {
            try
            {
                return _roomServices.SendSms(phone, message);
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }
    }
}