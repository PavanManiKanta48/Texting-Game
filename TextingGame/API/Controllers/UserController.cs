using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Persistence.Model;
using Service.Interface;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbTextingGameContext _dbUserContext;
        private readonly IUserServices _userService;
        public UserController(DbTextingGameContext dbUserContext, IUserServices iuserDetail)
        {
            _dbUserContext = dbUserContext;
            _userService = iuserDetail;
        }

        [HttpGet]
        public JsonResult GetUsers()
        {
            try
            {
                return new JsonResult(_userService.GetUsers().ToList());
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPost("UserRegister")]
        public JsonResult UserRegister(Register register)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;

                //check user exist or not
                bool isUserExist = _userService.CheckUserExist(register.EmailId!);
                if (isUserExist)
                    crudStatus.Message = "User Already Exists";
                else if (register.Password != register.ConfirmPassword)
                    crudStatus.Message = "Password and Confirm password not match";
                else
                {
                    _userService.Register(register);
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

        [HttpPost("LogIn")]
        public JsonResult UserLogIn(UserLogin logIn)
        {
            CrudStatus crudStatus = new CrudStatus();
            crudStatus.Status = false;
            try
            {
                var result = _userService.UserLogIn(logIn);
                if (result != null)
                {
                    crudStatus.Status = true;
                    crudStatus.Message = result;
                }
                else
                {
                    crudStatus.Message = "Email and Password doesnt match";
                }
                return new JsonResult(crudStatus);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }

        [HttpPut("ForgetPassword")]
        public JsonResult ForgetPassword(UserLogin changePwd)
        {
            try
            {
                CrudStatus crudStatus = new CrudStatus();
                crudStatus.Status = false;
                //check user exist or not
                bool isUserExist = _userService.CheckUserExist(changePwd.EmailId!);
                if (!isUserExist)
                    crudStatus.Message = "Email doesn't registered. Please Sign up";
                else if (changePwd.Password != changePwd.ConfirmPassword)
                    crudStatus.Message = "Password and Confirm password not match";
                else
                {
                    _userService.ForgetPassword(changePwd);
                    crudStatus.Status = true;
                    crudStatus.Message = "Password updated successfully";
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
