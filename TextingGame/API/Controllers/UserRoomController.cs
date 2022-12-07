using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoomController : ControllerBase
    {
        private readonly DbTextingGameContext _dbUserRoomContext;
        private readonly IUserRoomServices _userRoomServices;

        public UserRoomController(DbTextingGameContext dbContext, IUserRoomServices userRoomServices)
        {
            _dbUserRoomContext = dbContext;
            _userRoomServices = userRoomServices;
        }

        [HttpGet("GetUsersRoom")]
        public JsonResult GetUsersRoom()
        {
            try
            {
                return new JsonResult(_userRoomServices.GetUsersRoom().ToList());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("AddUserToRoom")]
        public JsonResult AddUserToRoom(TblUserRoom addUser)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool IsExistUserId = _userRoomServices.CheckUserId(addUser);
                if (IsExistUserId)
                {
                    bool IsExistroomId = _userRoomServices.CheckRoomId(addUser);
                    if (IsExistroomId)
                    {
                        bool userinroom = _userRoomServices.AddUserToRoom(addUser);
                        if (userinroom)
                        {
                            crudStatus.Status = true;
                            crudStatus.Message = "room added successfully";
                        }
                        else
                        {
                            crudStatus.Status = false;
                            crudStatus.Message = "Its Out Of limit";
                        }
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

        [HttpDelete]
        public JsonResult DeleteUserFromRoom(TblUserRoom deleteUserRoom)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool isExistUserRoomId = _userRoomServices.CheckRoomId(deleteUserRoom);
                if (isExistUserRoomId)
                {
                    _userRoomServices.DeleteUserFromRoom(deleteUserRoom);
                    crudStatus.Status = true;
                    crudStatus.Message = "person is succesfully deleted";
                }
                else
                {
                    crudStatus.Message = "Id is not matched person is not Deleted";
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
