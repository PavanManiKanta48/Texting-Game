using Domain;
using Domain.UserRoomModel;
using Persistence.Model;
using Service.Interface;

namespace Service.Services
{
    public class UserRoomServices : IUserRoomServices
    {
        private readonly DbTextingGameContext _dbUserRoomContext;

        public UserRoomServices(DbTextingGameContext dbContext)
        {
            _dbUserRoomContext = dbContext;
        }

        //.................Get User Room..................//
        public List<ListUserRoomResponse> GetUsersRoom(int roomId)
        {
            List<ListUserRoomResponse> userRooms = (from userRoom in _dbUserRoomContext.TblUserRooms
                                                    join users in _dbUserRoomContext.TblUsers on userRoom.UserId equals users.UserId
                                                    join rooms in _dbUserRoomContext.TblRooms on userRoom.RoomId equals rooms.RoomId
                                                    where userRoom.RoomId == roomId
                                                    select new ListUserRoomResponse()
                                                    {
                                                        RoomId = userRoom.RoomId,
                                                        UserId = users.UserId,

                                                    }).ToList();
            if (userRooms.Any())
            {
                return userRooms;
            }
            return new List<ListUserRoomResponse>();
        }

        //public List<TblRoom> Room(TblUserRoom user)
        //{
        //    //var room = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == user.RoomId).ToList()!;
        //    var room = _dbUserRoomContext.TblRooms.Where(r => r.Equals(user)).ToList();
        //    return room;
        //}

        public bool CheckUserId(int[]? checkUser)
        {
            foreach (var user in checkUser!)
            {
                var checkMessageUserId = _dbUserRoomContext.TblUsers.Where(r => r.UserId == user).FirstOrDefault();
                if (checkMessageUserId == null)
                    //return true;
                    //else
                    return false;
            }
            return true;

        }

        //............Check Room Id ..................//
        public bool CheckRoomId(int? checkroom)
        {
            var checkMessageRoomId = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == checkroom).FirstOrDefault();
            if (checkMessageRoomId != null)
                return true;
            else
                return false;
        }
        public BaseResponseModel ValidateUserRequestModel(CreateUserRoomRequestModel createUserRoomRequestModel)
        {
            if (CheckRoomId(createUserRoomRequestModel.RoomId))
            {
                if (CheckUserId(createUserRoomRequestModel.UserId))
                {
                    return new BaseResponseModel()
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        SuccessMessage = "user join roon succesfuly"
                    };
                }
            }
            return new BaseResponseModel()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                ErrorMessage = "user id and room id is not matched"
            };
        }
        //..........Add User Room...................//
        public BaseResponseModel AddUserToRoom(CreateUserRoomRequestModel createUserRoomRequestModel)
        {
            TblRoom room = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == createUserRoomRequestModel.RoomId).FirstOrDefault()!;
            List<TblUserRoom> userRooms = _dbUserRoomContext.TblUserRooms.Where(r => r.RoomId == createUserRoomRequestModel.RoomId).ToList()!;
            List<TblUserRoom> room1 = new List<TblUserRoom>();
            foreach (var userId in createUserRoomRequestModel.UserId!)
            {
                room1.Add(new TblUserRoom
                {
                    RoomId = createUserRoomRequestModel.RoomId,
                    UserId = userId,
                    IsActive = true,
                    ImpersonatedUserId = 2,
                    Score = 4.5,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 2,
                    UpdatedBy = 1
                });
            }

            try
            {
                if (userRooms.Count <= room.NumOfPeopele)
                {
                    _dbUserRoomContext.TblUserRooms.AddRange(room1);
                    _dbUserRoomContext.SaveChanges();
                    return new BaseResponseModel()
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        SuccessMessage = "user Room created successfully"
                    };
                }
                else
                {
                    return new BaseResponseModel()
                    {
                        StatusCode = System.Net.HttpStatusCode.BadRequest,
                        ErrorMessage = "limit is exceed",
                    };
                }
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
        public BaseResponseModel ValidateUserRequestModel(DeleteRoomRequsetModel deleteRoomRequsetModel)
        {
            if (CheckUserId(deleteRoomRequsetModel.UserId))
            {
                if (CheckRoomId(deleteRoomRequsetModel.RoomId))
                {
                    return new BaseResponseModel()
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        SuccessMessage = "user Room Deleted succesfully"
                    };
                }
            }
            return new BaseResponseModel()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                ErrorMessage = "user id and room id is not exist"
            };
        }

        //................Delete User Room................//
        public BaseResponseModel DeleteUserFromRoom(DeleteRoomRequsetModel deleteRoomRequsetModel)
        {
            //var user = _dbUserRoomContext.TblUserRooms.Where(x => x.UserId == deleteRoomRequsetModel.UserId[] && x.RoomId== deleteRoomRequsetModel.RoomId);
            List<TblUserRoom> users = new List<TblUserRoom>();

            foreach (var userId in deleteRoomRequsetModel.UserId!)
            {
                users.Add(_dbUserRoomContext.TblUserRooms.Where(x => x.UserId == userId && x.RoomId == deleteRoomRequsetModel.RoomId).FirstOrDefault()!);
            }
            _dbUserRoomContext.TblUserRooms.RemoveRange(users);
            try
            {
                _dbUserRoomContext.SaveChanges();
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    SuccessMessage = "User Room deleted successfully"
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
    }
}
