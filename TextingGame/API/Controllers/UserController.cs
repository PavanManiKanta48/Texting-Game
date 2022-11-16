using Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbTextingGameContext _dbContext;
        private readonly IuserDetail userService;
        public UserController(DbTextingGameContext dbContext, IuserDetail iuserDetail)
        {
            _dbContext = dbContext;
            userService = iuserDetail;
        }
        // GET: api/<UserController>
        [HttpGet]
        [Route("FetchUserDetail")]
        public JsonResult GetUserDetail()
        {
            try
            {
                return new JsonResult(userService.GetUser().ToList());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
        [HttpPost()]
        [Route("UserRegister")]
        public JsonResult UserRegister(Register register)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;

                //check user exist or not
                bool isUserExist = userService.CheckUserExist(register.EmailId!);
                if (isUserExist)
                    crudStatus.Message = "User Already Exists";
                else if (register.Password != register.ConfirmPassword)
                    crudStatus.Message = "Password and Confirm password not match";
                else
                {
                    userService.Register(register);
                    crudStatus.Status = true;
                    crudStatus.Message = "User Registered Successfully";
                }

                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
           [HttpPost()]
        [Route("LogIn")]
        public JsonResult LogIn(UserLogin logIn)
        {
            try
            {
                return new JsonResult(userService.UserLogIn(logIn));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
