using Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Service.Interface;
using Service.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class UserRoomController : ControllerBase
    {
        private readonly DbTextingGameContext _dbContext;
        private readonly IUserRoomServices _userRoomServices;

        public UserRoomController(DbTextingGameContext dbContext,IUserRoomServices userRoomServices)
        {
            _dbContext = dbContext;
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
                bool IsExistUserId = _userRoomServices.CheckExistUserId(addUser);
                if (!IsExistUserId)
                {
                    crudStatus.Message = "User unable to Join room because id is not matched";
                }
                else
                {
                    _userRoomServices.AddUserToRoom(addUser);
                    crudStatus.Status = true;
                    crudStatus.Message = "User Joined room succesfully";                    
                }
                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        [HttpDelete]
        public JsonResult DeleteUserFromRoom(TblUserRoom deleteUser)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool isExistUserId = _userRoomServices.CheckExistUserId(deleteUser);
                if (isExistUserId)
                {
                    _userRoomServices.DeleteUserFromRoom(deleteUser);
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
