﻿using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Persistence.Model;

namespace XUnitTesting
{
    public class DatabaseFixure : IDisposable
    {
        private readonly DbContextOptions<DbTextingGameContext> dbContextOptions = new DbContextOptionsBuilder<DbTextingGameContext>()
       .UseInMemoryDatabase(databaseName: "db_TextingGame")
        .Options;
        public DbTextingGameContext _context;

        public DatabaseFixure()
        {
            _context = new DbTextingGameContext(dbContextOptions);
            _context.Database.EnsureCreated();
            SeeDatabase();
        }
        public void SeeDatabase()
        {
            var user = new List<TblUser>()
            {
                new TblUser(){UserId = 1,UserName = "Anshika",EmailId = "anshika@gmail.com",Password = "anshi12",MobileNo = "7867765564",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now,IsActive = true},
                new TblUser(){UserId = 2,UserName = "Pavan",EmailId = "pavan@gmail.com",Password = "pavan12",MobileNo = "6523776845",CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now,IsActive = true}
            };
            _context.TblUsers.AddRange(user);
            _context.SaveChanges();
            var user1 = new List<TblRoom>()
            {
                new TblRoom(){RoomId = 1,RoomName = "FunGame",NumOfPeopele = 8,CreatedDate = DateTime.Now,UpdatedDate = DateTime.Now,IsActive = true},
                new TblRoom(){RoomId = 2,RoomName = "TextGame",NumOfPeopele = 10,CreatedDate = DateTime.Now,UpdatedDate= DateTime.Now,IsActive = true}
            };
            _context.TblRooms.AddRange(user1);
            _context.SaveChanges();
            var user2 = new List<TblUserRoom>()
            {
                new TblUserRoom(){UserRoomId=1,UserId=1,RoomId=1,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,IsActive = true},
                new TblUserRoom(){UserRoomId=2,UserId=2,RoomId=2,CreatedDate=DateTime.Now,UpdatedDate=DateTime.Now,IsActive = true}
            };
            _context.TblUserRooms.AddRange(user2);
            _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }
}
