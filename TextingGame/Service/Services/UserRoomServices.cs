using Domain;
using Domain.UserRoomModel;
using Persistence.Model;
using Service.Interface;

namespace Service.Services
{
    public class UserRoomServices : IUserRoomServices
    {
        private readonly DbTextingGameContext _dbUserRoomContext;
        private readonly Random random = new Random();

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
            return checkMessageRoomId != null;
            //if (checkMessageRoomId != null)
            //    return true;
            //else
            //    return false;
        }       
        public BaseResponseModel ValidateUserRequestModel(CreateUserRoomRequestModel createUserRoomRequestModel)
        {
            List<TblUserRoom> userRooms = _dbUserRoomContext.TblUserRooms.Where(r => r.RoomId == createUserRoomRequestModel.RoomId).ToList()!;
            if (!CheckRoomId(createUserRoomRequestModel.RoomId))
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = "Room id is not valid"
                };
            }
            if (!CheckUserId(createUserRoomRequestModel.UserId))
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    ErrorMessage = "user id not valid"
                };
            }  
            if(userRooms.Count<=5)
            {
                return new BaseResponseModel()
                {
                    StatusCode = System.Net.HttpStatusCode.OK,
                    SuccessMessage = "user joined successfully"
                };
            }
            return new BaseResponseModel()
            {
                StatusCode = System.Net.HttpStatusCode.BadRequest,
                SuccessMessage = "Nof Of people Reached 5"
            };
        }
        //..........Add User Room...................//
        public BaseResponseModel AddUserToRoom(CreateUserRoomRequestModel createUserRoomRequestModel)
        {
            //TblRoom room = _dbUserRoomContext.TblRooms.Where(r => r.RoomId == createUserRoomRequestModel.RoomId).FirstOrDefault()!;
            List<TblUserRoom> userRooms = _dbUserRoomContext.TblUserRooms.Where(r => r.RoomId == createUserRoomRequestModel.RoomId).ToList()!;

            List<int> roomIds = new List<int>();
            foreach(var userRoom in userRooms)
            {
                roomIds.Add((int)userRoom.UserId!);
            }
            int index = random.Next(userRooms.Count);

            List<TblUserRoom> tblUserRooms = new List<TblUserRoom>();
            foreach (var userId in createUserRoomRequestModel.UserId!)
            {
                tblUserRooms.Add(new TblUserRoom
                {
                    RoomId = createUserRoomRequestModel.RoomId,
                    UserId = userId,
                    IsActive = true,
                    ImpersonatedUserId = roomIds[index],
                    Score = 0,
                    CreatedDate = DateTime.Now,
                    UpdatedDate = DateTime.Now,
                    CreatedBy = 2,  //session 
                    UpdatedBy = 1   //session 
                });
            }           
            try
            {
                //if (userRooms.Count <= room.NumOfPeopele)
                //{
                    _dbUserRoomContext.TblUserRooms.AddRange(tblUserRooms);
                    _dbUserRoomContext.SaveChanges();
                    return new BaseResponseModel()
                    {
                        StatusCode = System.Net.HttpStatusCode.OK,
                        SuccessMessage = "user Room created successfully"
                    };
                //}
                //else
                //{
                    //return new BaseResponseModel()
                    //{
                    //    StatusCode = System.Net.HttpStatusCode.BadRequest,
                    //    ErrorMessage = "limit is exceed",
                    //};
                //}
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
