using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
using Persistence;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    //..............Dependencies Injection................//
    public class UserServices : EncryptServices, IuserDetail
    {
        private readonly DbTextingGameContext _dbContext;
        private readonly IEncrypt _encrypt;
        public UserServices(DbTextingGameContext dbContext, IEncrypt encrypt)
        {
            _dbContext = dbContext;
            _encrypt = encrypt;
        }
        //...........fetch User detail.........//
        public List<TblUserDetail> GetUser()
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
        public CrudStatus ForgetPassword(ChangePassword changePwd)
        {
            
            string encryptPassword = _encrypt.EncodePasswordToBase64(changePwd.NewPassword!);
            string encryptConfirmPassword = _encrypt.EncodePasswordToBase64(changePwd.ConfirmPassword!);
            var user = _dbContext.TblUserDetails.Where(x => x.EmailId == changePwd.EmailId).FirstOrDefault()!;
            if (user != null)
            {
                if (encryptPassword == encryptConfirmPassword)
                {
                    user!.Password = encryptPassword;
                    user.UpdatedDate = DateTime.Now;
                    _dbContext.Entry(user).State = EntityState.Modified;
                    _dbContext.SaveChanges();
                    
                    return new CrudStatus() { Status = true, Message = "Password updated successfully" }; 
                }
                return new CrudStatus() { Status = true, Message = "you Entered Wring Password" };
            }
            else
            {
                return new CrudStatus() { Status = true, Message = "Email was not registered" };
            }
        }
    }
}
