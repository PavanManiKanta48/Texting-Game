﻿using Domain;
using Microsoft.AspNetCore.Mvc;
using Persistence;
using Service.Interface;
using Service.Services;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DbTextingGameContext _dbContext;
        private readonly IUserServices userService;
        public UserController(DbTextingGameContext dbContext, IUserServices iuserDetail)
        {
            _dbContext = dbContext;
            userService = iuserDetail;
        }
       
        [HttpGet]        
        public JsonResult GetUsers()
        {
            try
            {
                return new JsonResult(userService.GetUsers().ToList());
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

        [HttpPost]
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

        [HttpPut("ForgetPassword")]        
        public JsonResult ForgetPassword(string Mail, Register changePwd)
        {
            try
            {
                changePwd.EmailId = Mail;
                return new JsonResult(userService.ForgetPassword(changePwd));
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
    }
}
