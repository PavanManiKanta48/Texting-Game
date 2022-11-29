using Persistence;
using Service.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace XUnitTesting
{
    [CollectionDefinition("DataBase Collection")]
    public class DatabaseCollection : ICollectionFixture<DatabaseFixure>
    { 
    }
    [Collection("DataBase Collection")]
    public class RoomServicesTest
    {
        private readonly DatabaseFixure _fixure;
        private readonly RoomServices _services;

        public RoomServicesTest(DatabaseFixure fixure)
        {
            _fixure = fixure;
            _services = new RoomServices(_fixure.context);
        }

        [Fact]
        public void GetAll_roomDetails()
        {
            var result = _services.GetRoom();
            var items = Assert.IsType<List<TblRoom>>(result);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Check_New_with_CheckExtistRoomId()
        {
            //Arrange
            var Room = new TblRoom()
            {
                RoomId = 3,
                UserId = 2,
                RoomName = "Denish",
                NumOfPeopele = 2,
                CheckIn = DateTime.Now,
                Updated = null,
                IsActive = true
            };
            //Act
            var result = _services.CheckExistUserId(Room);
            var expected = "already room succesfull";
            //Assert
            Assert.True(result, expected);
        }

        [Fact]
        public void Check_Present_with_CheckExtisRoomId()
        {
            //Arrange
            var Room = new TblRoom()
            {
                RoomId = 1,
                UserId = 2,
                RoomName = "TextGame",
                NumOfPeopele = 10,
                CheckIn = DateTime.Now,
                Updated = null,
                IsActive = true
            };
            //Act
            var result = _services.CheckExistUserId(Room);
            var expected = "created room succesfull";
            //Assert
            Assert.True(result, expected);
        }

        [Fact]
        public void Check_with_RoomUpdate_CorrectId()
        {
            //Arrange
            var updateRoom = new TblRoom()
            {
                RoomId = 2,
                UserId = 2,
                RoomName = "Ludo",
                NumOfPeopele = 9,
                CheckIn = DateTime.Now,
                Updated = null,
                IsActive = true
            };
            //Act
            var result = _services.CheckExistRoomId(updateRoom);
            var expected = "Update Room Succesfull";
            //Assert
            Assert.True(result,expected);
        }

        [Fact]
       public void Check_with_RoomUpdate_WrongId()
        {
            //Arrange
            var updateRoom = new TblRoom()
            {
                RoomId = 8,
                UserId = 22,
                RoomName = "textGame",
                NumOfPeopele = 12,
                CheckIn = DateTime.Now,
                Updated = null,
                IsActive = true
            };
            //Act
            var result = _services.CheckExistRoomId(updateRoom);
            var expected = "Update Id is not matched";
            //Assert
            Assert.True(result,expected);
        }

        [Fact]
        public void Check_with_deleteRoom_CorrectId()
        {
            //Arrange
            var deleteRoom = new TblRoom()
            {
                RoomId = 1,
         };
            //Act
            var result = _services.CheckExistRoomId(deleteRoom);
            var expected = "Delete Room Is succesfull";
            //Assert
            Assert.True(result,expected);
        }

        [Fact]
        public void Check_with_deleteRoom_WrongId()
        {
            //Arrange
            var deleteRoom = new TblRoom()
            {
                RoomId = 5,
            };
            //Act
            var result = _services.CheckExistRoomId(deleteRoom);
            var expected = "Delete id is not matched";
            //Assert
            Assert.False(result,expected);
        }
    }
}
