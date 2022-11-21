using API.Controllers;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APITests.Controllers.User
{
    //Xunit testing
    public class UserControllerTests
    {
        private readonly UserController userController;
        private readonly Mock<IUserServices> userServiceBL;

        public UserControllerTests()
        {
            userServiceBL = new Mock<IUserServices>();
            userController = new UserController(userServiceBL.Object);
        }

        [Fact]
        public void CreateProjectResponseDataTest1()
        {
            //Arrange
            string createProjectResponseDataTest1Path = Path.Combine(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName, "Controllers", "User", "TestFiles", "CreateProjectResponseDataTest1.json");
            string createProjectResponseData = File.ReadAllText(createProjectResponseDataTest1Path);
            List<TblUserDetail> expectedUsers = JsonConvert.DeserializeObject<List<TblUserDetail>>(createProjectResponseData);
            userServiceBL.Setup(method => method.GetUsers()).Returns(expectedUsers);

            //Act
            List<TblUserDetail> actualUsers = userController.GetUsers();

            //Assert
            Assert.Equal(expectedUsers, actualUsers);
        }
    }
}
