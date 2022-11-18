using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Persistence;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{    
    public class UserServices : EncryptServices, IUserServices
    {
        private readonly DbTextingGameContext _dbContext;
        private readonly IEncryptServices _encrypt;
        public UserServices(DbTextingGameContext dbContext, IEncryptServices encrypt)
        {
            _dbContext = dbContext;
            _encrypt = encrypt;
        }

        //...........fetch User detail.........//
        public List<TblUserDetail> GetUsers()
        {
            var users = _dbContext.TblUserDetails.ToList();
            return users;
        }

        //............Check User Email...........// 
        public bool CheckUserExist(string email)
        {
            var user = _dbContext.TblUserDetails.Where(x => x.EmailId == email).FirstOrDefault();
            return user != null;
        }

        //............Check Password .................//
        public void Register(Register register)
        {
            EncryptServices encrypt1 = new EncryptServices();
            string encryptPassword = encrypt1.EncodePasswordToBase64(register.Password!);
            register.Password = encryptPassword;
            register.CreatedDate = DateTime.Now;
            register.UpdatedDate = null;
            _dbContext.TblUserDetails.Add(register);
            _dbContext.SaveChanges();
        }

        //...........User Login.....................//
        public bool UserLogIn(UserLogin login)
        {
            string encryptPassword = _encrypt.EncodePasswordToBase64(login.Password!);
            var user1 = _dbContext.TblUserDetails.Where(x => x.EmailId == login.EmailId && x.Password == encryptPassword).FirstOrDefault()!;
           if (user1 != null)
           {
                return true;
           }              
            return false;
        }

        //...........Forget Password.....................//
        public CrudStatus ForgetPassword(UserLogin changePwd)
        {
            string encryptPassword = _encrypt.EncodePasswordToBase64(changePwd.Password!);
            TblUserDetail user = _dbContext.TblUserDetails.Where(x => x.EmailId == changePwd.EmailId).FirstOrDefault()!;
            if (user != null)
            {
                if (changePwd.Password == changePwd.ConfirmPassword)
                {
                    user!.Password = encryptPassword;
                    user.UpdatedDate = DateTime.Now;
                    _dbContext.Entry(user).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    return new CrudStatus() { Status = true, Message = "Password updated successfully" };
                }
                return new CrudStatus() { Status = false, Message = "Password and Confirm password not matched" };
            }
            else
            {
                return new CrudStatus() { Status = false, Message = "Email doesn't registered. Please Sign up" };
            }            
        }
    }
}
