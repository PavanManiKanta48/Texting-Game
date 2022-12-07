using Domain;
using Service.Services;

namespace XUnitTesting
{
    [CollectionDefinition("DataBase Collection")]
    public class DatabaseCollection1 : ICollectionFixture<DatabaseFixure>
    {
    }

    [Collection("DataBase Collection")]
    public class UserRoomServicesTest
    {
        private readonly DatabaseFixure _fixure;
        private readonly UserRoomServices _userservices;
        public UserRoomServicesTest(DatabaseFixure fixure)
        {
            _fixure = fixure;
            _userservices = new UserRoomServices(_fixure._context);
        }
        [Fact]
        public void Get_UserRoomsDetails()
        {
            var result = _userservices.GetUsersRoom();
            var items = Assert.IsType<List<TblUserRoom>>(result);
            Assert.Equal(2, items.Count);
        }

        [Fact]
        public void Adding_newUserToRoom()
        {
            //Arrange
            var addingtoRoom = new TblUserRoom()
            {
                PersonId = 3,
                RoomId = 1,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsActive = true
            };
            //Act
            var result = _userservices.AddUserToRoom(addingtoRoom);
            var expected = "Room Added Successfull";
            //Assert
            Assert.True(result, expected);
        }
        [Fact]
        public void Adding_ExsistingUserToRoom()
        {
            //Arrange
            var addingtoRoom = new TblUserRoom()
            {
                PersonId = 3,
                RoomId = 1,
                UserId = 2,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsActive = true
            };
            //Act
            var result = _userservices.AddUserToRoom(addingtoRoom);
            var expected = "already existed";
            //Assert
            Assert.True(result, expected);
        }
        [Fact]
        public void Delete_ExistingUserFromRoom()
        {
            //Arrange
            var deleteUser = new TblUserRoom()
            {
                PersonId = 5,
                RoomId = 4,
                UserId = 1,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsActive = true
            };
            //Act
            var result = _userservices.DeleteUserFromRoom(deleteUser);
            var expected = "Deleted from Room";
            //Assert
            Assert.True(result, expected);
        }
        [Fact]
        public void Delete_newUserFromRoom()
        {
            //Arrange
            var deleteUser = new TblUserRoom()
            {
                PersonId = 6,
                RoomId = 4,
                UserId = 3,
                CreatedDate = DateTime.Now,
                UpdatedDate = null,
                IsActive = true
            };
            //Act
            var result = _userservices.DeleteUserFromRoom(deleteUser);
            var expected = "Deleted from Room";
            //Assert
            Assert.True(result, expected);
        }

    }
}
