using Domain;
using Microsoft.EntityFrameworkCore;
using Moq;
using Persistence;
using Service.Interface;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTesting
{
    public class UserServicesTest : IClassFixture<DatabaseFixure>
    {
        //private readonly DatabaseFixure _fixure;
        //private readonly UserServices _services;
        //Mock<IEncryptServices> _encrypt;
        //public UserServicesTest(DatabaseFixure fixure)
        //{
        //    _fixure = fixure;
        //    _encrypt = new Mock<IEncryptServices>();
        //    _services = new UserServices(_fixure.context, _encrypt.Object);
        //}

        ////.........Get all User..........//
        //[Fact]
        //public void GetAll_Test()
        //{
        //    var result = _services.GetUsers();
        //    //Act
        //    var items = Assert.IsType<List<TblUserDetail>>(result);
        //    //Assert
        //    Assert.Equal(2, items.Count);
        //}

        ////...........check exist user............//
        //[Fact]
        //public void Check_Extist_with_CheckExtistUser()
        //{
        //    //Arrange
        //    var user1 = new Register()
        //    {
        //        UserName = "Anshika",
        //        EmailId = "anshika@gmail.com",
        //        Password = "anshi12",
        //        ConfirmPassword = "anshi12",
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = null,
        //        IsActive = true
        //    };

        //    //Act
        //    var result = _services.Register(user1);

        //    //Assert
        //    Assert.True(result);
        //}

        ////..............check new user..............//
        //[Fact]
        //public void Check_New_with_CheckExtistUser()
        //{
        //    //Arrange
        //    var user = new Register()
        //    {
        //        UserName = "shirien",
        //        EmailId = "shirien@gmail.com",
        //        Password = "shirien12",
        //        ConfirmPassword = "shirien12",
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = null,
        //        IsActive = true
        //    };

        //    //Act
        //    var result = _services.Register(user);

        //    //Assert
        //    Assert.True(result);
        //}

        ////.................check confirm password..........//
        //[Fact]
        //public void Check_Correct_ConfirmPassword()
        //{
        //    //Arrange
        //    var user = new Register()
        //    {
        //        UserName = "pavan",
        //        EmailId = "pavan@gmail.com",
        //        Password = "pavan12",
        //        ConfirmPassword = "pavan12",
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = null,
        //        IsActive = true
        //    };

        //    //Act
        //    var result = _services.Register(user);

        //    //Assert
        //    Assert.True(result);
        //}

        ////..............check wrong confirm password..........//
        //[Fact]
        //public void Check_Wrong_ConfirmPassword()
        //{
        //    //Arrange
        //    var user = new Register()
        //    {
        //        UserName = "Anshika",
        //        EmailId = "anshika@gmail.com",
        //        Password = "anshi12",
        //        ConfirmPassword = "4321",
        //        CreatedDate = DateTime.Now,
        //        UpdatedDate = null,
        //        IsActive = true
        //    };

        //    //Act
        //    var result = _services.Register(user);

        //    //Assert
        //    Assert.True(result);
        //}

        ////..........login with correct mail and password.........//
        //[Fact]
        //public void LogIn_with_correct_mail_password()
        //{
        //    var login = new UserLogin()
        //    {
        //        EmailId = "anshika@gmail.com",
        //        Password = "anshi12",
        //        ConfirmPassword = "anshi12"
        //    };
        //    _encrypt.Setup(method => method.EncodePasswordToBase64(login.Password)).Returns(login.Password);
        //    var result = _services.UserLogIn(login);
        //    Assert.True(result);
        //}

        ////.................check login with correct mail and wrong password..........//
        //[Fact]
        //public void LogIn_with_correct_mail_wrong_password()
        //{
        //    //Arrange
        //    var user = new UserLogin()
        //    {
        //        EmailId = "anshika@gmail.com",
        //        Password = "an1234",
        //        ConfirmPassword = "an1234"
        //    };
        //    _encrypt.Setup(method => method.EncodePasswordToBase64(user.Password)).Returns(user.Password);

        //    //Act
        //    var result = _services.UserLogIn(user);

        //    //Assert
        //    Assert.False(result);
        //}

        ////.............check login with new mail...............//
        //[Fact]
        //public void LogIn_with_new_mail()
        //{
        //    //Arrange
        //    var user = new UserLogin()
        //    {
        //        EmailId = "pavan12@gmail.com",
        //        Password = "pava123",
        //        ConfirmPassword = "pava123"
        //    };
        //    _encrypt.Setup(method => method.EncodePasswordToBase64(user.Password)).Returns(user.Password);

        //    //Act
        //    var result = _services.UserLogIn(user);

        //    //Assert
        //    Assert.False(result);
        //}

        ////..................check forgot password..............//
        //[Fact]
        //public void Forget_Password_Test()
        //{
        //    //Arrange
        //    var user = new UserLogin()
        //    {
        //        EmailId = "anshika@gmail.com",
        //        Password = "an123",
        //        ConfirmPassword = "an123"
        //    };
        //    _encrypt.Setup(method => method.EncodePasswordToBase64(user.Password)).Returns(user.Password);

        //    //Act
        //    var result = _services.ForgetPassword(user);

        //    //Assert
        //    Assert.True(result);
        //}
    }
}

