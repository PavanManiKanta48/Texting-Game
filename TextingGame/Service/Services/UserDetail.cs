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
    public class UserDetail : Encrypt, IuserDetail
    {
        private readonly DbTextingGameContext _dbContext;
        private readonly IEncrypt _encrypt;
        public UserDetail(DbTextingGameContext dbContext, IEncrypt encrypt)
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
            Encrypt encrypt1 = new Encrypt();
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
    }
}
