using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence.Model;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly DbTextingGameContext _dbMessageContext;
        private readonly IMessageServices _messageServices;

        public MessageController(DbTextingGameContext dbContext, IMessageServices messageServices)
        {
            _dbMessageContext = dbContext;
            _messageServices = messageServices;
        }

        [HttpGet("GetUserMessage")]
        public JsonResult GetUsersMessage(int RoomId)
        {
            try
            {

                return new JsonResult(_messageServices.GetMessages(RoomId).ToList());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("AddUserMessage")]
        public JsonResult AddUserMessage(string Message, int RoomId, int UserId)
        {
            try
            {
                TblMessage message = new TblMessage();
                {
                    message.RoomId = RoomId;
                    message.UserId = UserId;
                    message.Message = Message;
                };
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool IsExistUserId = _messageServices.CheckUserId(message);
                if (IsExistUserId)
                {
                    bool IsExistroomId = _messageServices.CheckRoomId(message);
                    if (IsExistroomId)
                    {
                        _messageServices.AddMessages(Message, RoomId, UserId);
                        crudStatus.Status = true;
                        crudStatus.Message = "message sent succesfull";
                    }
                    else
                    {
                        crudStatus.Status = false;
                        crudStatus.Message = "room id is not exist";
                    }
                }
                else
                {
                    crudStatus.Status = false;
                    crudStatus.Message = "User ID is not matched";
                }
                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
