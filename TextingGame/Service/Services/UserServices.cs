using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Persistence;
using Service.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service.Services
{
    public class UserServices : EncryptServices, IUserServices
    {
        private readonly DbTextingGameContext _dbUserContext;
        private readonly IEncryptServices _encrypt;
        private readonly IGenrateToken _genrateToken;

        public UserServices(DbTextingGameContext dbUserContext, IEncryptServices encrypt, IGenrateToken genrateToken)
        {
            _dbUserContext = dbUserContext;
            _encrypt = encrypt;
           _genrateToken = genrateToken;
        }

        //...........fetch User detail.........//
        public List<TblUserDetail> GetUsers()
        {
            List<TblUserDetail> result = (from user in _dbUserContext.TblUserDetails
                                          select new TblUserDetail
                                          {
                                              UserId = user.UserId,
                                              UserName = user.UserName,
                                              EmailId = user.EmailId,
                                              MobileNo = user.MobileNo,
                                              CreatedDate = user.CreatedDate,
                                              UpdatedDate = user.UpdatedDate,
                                              IsActive = user.IsActive
                                          }).ToList();
            return result.ToList();
        }

        //............Check User Email...........// 
        public bool CheckUserExist(string email)
        {
            var user = _dbUserContext.TblUserDetails.Where(x => x.EmailId == email).FirstOrDefault();
            if (user != null)
                return true;
            else
                return false;
        }

        //............Check Password .................//
        public string Register(Register register)
        {
            EncryptServices encrypt1 = new EncryptServices();
            string encryptPassword = encrypt1.EncodePasswordToBase64(register.Password!);
            register.Password = encryptPassword;
            register.CreatedDate = DateTime.Now;
            register.UpdatedDate = null;
            register.IsActive = true;
            _dbUserContext.TblUserDetails.Add(register);
            _dbUserContext.SaveChanges();
            var token = _genrateToken.GenerateToken(register);
            return token;
        }

        //...........User Login.....................//
        public string UserLogIn(UserLogin user)
        {
            string encryptPassword = _encrypt.EncodePasswordToBase64(user.Password!);
            var login = _dbUserContext.TblUserDetails.Where(x => x.EmailId == user.EmailId && x.Password == encryptPassword).FirstOrDefault()!;
            if (user != null)
            {
                var token = _genrateToken.GenerateToken(login);
                return token;
            }
            return null;
        }

        //...........Forget Password.....................//
        public bool ForgetPassword(UserLogin changePwd)
        {
            var user = _dbUserContext.TblUserDetails.Where(x => x.EmailId == changePwd.EmailId).FirstOrDefault()!;
            string encryptPassword = _encrypt.EncodePasswordToBase64(changePwd.Password!);
            user.Password = encryptPassword;
            _dbUserContext.Entry(user).State = EntityState.Modified;
            _dbUserContext.SaveChanges();
            return true;
        }
    }
}
