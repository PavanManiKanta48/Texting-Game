using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using Persistence;
using Service.Interface;
using Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly DbTextingGameContext _dbcontext;
        private readonly IRoomServices _roomServices;
        public RoomController(DbTextingGameContext dbContext, IRoomServices roomServices)
        {
            _dbcontext = dbContext;
            _roomServices = roomServices;
        }

        // GET: api/<RoomController>
        [HttpGet]
        public JsonResult GetRoom()
        {
            try
            {
                return new JsonResult(_roomServices.GetRoom().ToList());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost]
        public JsonResult CreateRoom(TblRoom room)
        {
            try
            {

                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool IsExistUserId = _roomServices.CheckExistUserId(room);
                if (!IsExistUserId)
                {
                    
                    crudStatus.Message = "User unable to Create room because id is not matched";
                }
                else
                {

                    _roomServices.CreateRoom(room);
                    crudStatus.Status = true;
                    crudStatus.Message = "User Create room succesfully";
                }
                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut]
        public JsonResult UpdateRoom(TblRoom uroom)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool IsExistRoomId = _roomServices.CheckExistRoomId(uroom);
                if (!IsExistRoomId)
                {
                    crudStatus.Message = "Id not matched";
                }
                else
                {
                    _roomServices.UpdateRoom(uroom);
                    crudStatus.Status = true;
                    crudStatus.Message = "user updated succesfully";
                }
                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpDelete]
        public JsonResult DeleteRoom(TblRoom room)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                bool isExistRoomId = _roomServices.CheckExistRoomId(room);
                if (isExistRoomId)
                {
                    _roomServices.DeleteRoom(room);
                    crudStatus.Status = true;
                    crudStatus.Message = "room is succesfully deleted";
                }
                else
                {
                    crudStatus.Message = "Id is not matched room is not Deleted";
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