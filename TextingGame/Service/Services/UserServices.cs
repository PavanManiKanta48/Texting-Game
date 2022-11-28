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
        private readonly DbTextingGameContext _dbContext;
        private readonly IEncryptServices _encrypt;
        private readonly IConfiguration _configuration;
        public UserServices(DbTextingGameContext dbContext, IEncryptServices encrypt, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _encrypt = encrypt;
            _configuration= configuration;

        }

        //...........fetch User detail.........//
        public List<TblUserDetail> GetUsers()
        {
            List<TblUserDetail> result = (from user in _dbContext.TblUserDetails
                                          select new TblUserDetail
                                          {
                                              UserId = user.UserId,
                                              UserName = user.UserName,
                                              EmailId = user.EmailId,
                                              IsActive = user.IsActive,
                                              CreatedDate = user.CreatedDate,
                                              UpdatedDate = user.UpdatedDate
                                          }).ToList();
            return result.ToList();

            //var users = _dbContext.TblUserDetails.ToList();
            //return users;
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
        public string UserLogIn(UserLogin login)
        {
            string encryptPassword = _encrypt.EncodePasswordToBase64(login.Password!);
            var user1 = _dbContext.TblUserDetails.Where(x => x.EmailId == login.EmailId && x.Password == encryptPassword).FirstOrDefault()!;
            if (user1 != null)
            {
                var token = GenerateToken(login);
                return token;
            }
            return null;
        }
        private string GenerateToken(UserLogin user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier,user.EmailId!),
                 new Claim(ClaimTypes.NameIdentifier,user.Password!),
            };
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Audience"],
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);


            return new JwtSecurityTokenHandler().WriteToken(token);

        }

        //...........Forget Password.....................//
        public void ForgetPassword(UserLogin changePwd)
        {
            TblUserDetail user = _dbContext.TblUserDetails.Where(x => x.EmailId == changePwd.EmailId).FirstOrDefault()!;
            string encryptPassword = _encrypt.EncodePasswordToBase64(changePwd.Password!);
            user.Password = encryptPassword;
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}
