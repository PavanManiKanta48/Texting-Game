using Domain;
using Domain.UserModel;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Model;
using Service.Interface;

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
        public List<TblUser> GetUsers()
        {
            List<TblUser> result = (from user in _dbUserContext.TblUsers
                                    select new TblUser
                                    {
                                        UserName = user.UserName,
                                        EmailId = user.EmailId,
                                        MobileNo = user.MobileNo,
                                    }).ToList();
            return result.ToList();
        }

        //............Check User Email...........// 

        public BaseResponseModel ValidateUserRequestModel(CreateUserRequestmodel createUserRequestmodel)
        {
            if (CheckUserExist(createUserRequestmodel.EmailId!))
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = "User Already Exists"
                };
            }
            if (createUserRequestmodel.Password != createUserRequestmodel.ConfirmPassword)
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = "Password and Confirm password not match"
                };
            }
            return new BaseResponseModel()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
            };
        }
        public bool CheckUserExist(string email)
        {
            var user = _dbUserContext.TblUsers.Where(x => x.EmailId == email).FirstOrDefault();
            if (user != null)
                return true;
            else
                return false;
        }

        //............Check Password .................//
        public BaseResponseModel Register(CreateUserRequestmodel createUserRequestmodel)
        {
            //Refactor the following code later using Automapper
            //Convert API model to DB model
            EncryptServices encrypt1 = new EncryptServices();

            TblUser tblUser = new TblUser()
            {
                UserName = createUserRequestmodel.UserName,
                Password = encrypt1.EncodePasswordToBase64(createUserRequestmodel.Password!),
                MobileNo = createUserRequestmodel.MobileNo,
                EmailId = createUserRequestmodel.EmailId,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true
            };
            _dbUserContext.TblUsers.Add(tblUser);
            try
            {
                _dbUserContext.SaveChanges();
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    SuccessMessage = "User created successfully"
                };
            }
            catch (Exception ex)
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = string.Format("Creating an user failed. Exception details are: {0}", ex.Message)
                };
            }
        }

        //...........User Login.....................//
        public string UserLogIn(UserLogin user)
        {
            string encryptPassword = _encrypt.EncodePasswordToBase64(user.Password!);
            var login = _dbUserContext.TblUsers.Where(x => x.EmailId == user.EmailId && x.Password == encryptPassword).FirstOrDefault()!;
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
            var user = _dbUserContext.TblUsers.Where(x => x.EmailId == changePwd.EmailId).FirstOrDefault()!;
            string encryptPassword = _encrypt.EncodePasswordToBase64(changePwd.Password!);
            user.Password = encryptPassword;
            _dbUserContext.Entry(user).State = EntityState.Modified;
            _dbUserContext.SaveChanges();
            return true;
        }
    }
}
