using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class UserDetail :Encrypt,IuserDetail
{
        private readonly DbTextingGameContext _dbContext;
        public UserDetail(DbTextingGameContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<TblUserDetail> GetUser()
        {
            var users = _dbContext.TblUserDetails.ToList();
            return users;
        }
        public bool Register(TblUserDetail tblUser)
        {
            var email = _dbContext.TblUserDetail.Find(tblUser.EmailId);
            if (email != null)
            {
                return false;
            }
            else
            {
                _dbContext.TblUserDetail.Add(tblUser);
                var password = _dbContext.TblUserDetail.Find(tblUser.Password);
                if (password != null)
                {
                    Encrypt encrypt = new Encrypt();
                    encrypt.Decrypt_Password(tblUser.Password);
                }
                _dbContext.SaveChanges();
                return true;
            }
        }
        public bool UpdateUserDetail(TblUserDetail tblUser)
        {
            _dbContext.TblUserDetails.Update(tblUser);
            _dbContext.SaveChanges();
            return true;
        }
        public bool DeleteUserDetail(TblUserDetail tblUser)
        {
           _dbContext.Remove(tblUser);
            return true;
        }
    }

    internal class _DbTextingGameContext
    {
    }
}
