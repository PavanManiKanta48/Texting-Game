using Domain;
using Domain.RoomModel;
using Domain.UserModel;
using Domain.UserRoomModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Persistence.Model;
using Service.Interface;
using Service.Services;
using Twilio.TwiML.Voice;

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
                return _roomServices.GetRoom(userId);
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
                BaseResponseModel errorModel = _roomServices.ValidateUserRequestModel(createRoomRequestModel);
                if (errorModel.StatusCode == System.Net.HttpStatusCode.BadRequest)
                {
                    return errorModel;
                }
                return _roomServices.CreateRoom(createRoomRequestModel);
               
            }
            catch (Exception ex)
            {
                throw new(ex.Message);
            }
        }

        [HttpPut]
        public JsonResult UpdateRoom(TblRoom room)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool IsExistRoomId = _roomServices.CheckExistRoomId(room);
                if (!IsExistRoomId)
                {
                    crudStatus.Message = "Room Id not matched";
                }
                else
                {
                    _roomServices.UpdateRoom(room);
                    crudStatus.Status = true;
                    crudStatus.Message = "User update room succesfully";
                }
                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        //[Authorize]
        [HttpPost("send message")]
        public JsonResult SendingSms(double phone, string message) //int roomid
        {
            try
            {

                return new JsonResult(_roomServices.SendSms(phone, message));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}