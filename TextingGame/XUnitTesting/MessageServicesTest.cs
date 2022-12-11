using Domain;
using Domain.Messagemodel;
using Domain.UserModel;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace XUnitTesting
{
        [Collection("DataBase Collection")]
        public class MessageServicesTest
        {
            private readonly DatabaseFixure _fixure;
            private readonly MessageServices _messageservices;
            public MessageServicesTest(DatabaseFixure fixure)
            {
                _fixure = fixure;
            _messageservices = new MessageServices(_fixure._context);
            }
        //[Fact]
        //public void Get_All_Test()
        //{
        //    var result = _messageservices.GetRoom();
        //    //Act
        //    var items = Assert.IsType<List<MessageResponse>>(result);
        //    //Assert
        //    Assert.Equal(2, items.Count);
        //}

        [Fact]
        public void CheckNewwithCheckExtistUser()
        {
            var user = new CreateMessageRequestModel()
            {
                RoomId = 1,
                Message = "welcome",
            };
            //Act
            var result = _messageservices.AddMessages(user);
            BaseResponseModel expexted = new BaseResponseModel()
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                SuccessMessage = "Message send successfully"
            };
            //Assert
            Assert.Equal(result.SuccessMessage, expexted.SuccessMessage);
                }
        }
}
