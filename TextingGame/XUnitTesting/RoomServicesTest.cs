using Domain;
using Persistence.Model;
using Service.Services;

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
            _services = new RoomServices(_fixure._context);
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
                RoomName = "Denish",
                NumOfPeopele = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
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
                RoomName = "TextGame",
                NumOfPeopele = 10,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
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
                RoomName = "Ludo",
                NumOfPeopele = 9,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true
            };
            //Act
            var result = _services.CheckExistRoomId(updateRoom);
            var expected = "Update Room Succesfull";
            //Assert
            Assert.True(result, expected);
        }

        [Fact]
        public void Check_with_RoomUpdate_WrongId()
        {
            //Arrange
            var updateRoom = new TblRoom()
            {
                RoomId = 8,
                RoomName = "textGame",
                NumOfPeopele = 12,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now,
                IsActive = true
            };
            //Act
            var result = _services.CheckExistRoomId(updateRoom);
            var expected = "Update Id is not matched";
            //Assert
            Assert.False(result, expected);
        }
    }
}
