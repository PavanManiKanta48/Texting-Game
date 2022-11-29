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
   public class DatabaseFixure : IDisposable
    {
        private readonly DbContextOptions<DbTextingGameContext> dbContextOptions = new DbContextOptionsBuilder<DbTextingGameContext>()
       .UseInMemoryDatabase(databaseName: "db_TextingGame")
        .Options;
        public DbTextingGameContext context;

        public DatabaseFixure()
        {
            context = new DbTextingGameContext(dbContextOptions);
            context.Database.EnsureCreated();
            SeeDatabase();
        }
        public void SeeDatabase()
        {
            var user = new List<TblUserDetail>()
            {
                new TblUserDetail(){UserId = 1,UserName = "Anshika",EmailId = "anshika@gmail.com",Password = "anshi12",CreatedDate = DateTime.Now,UpdatedDate = null,IsActive = true},
                new TblUserDetail(){UserId = 2,UserName = "Pavan",EmailId = "pavan@gmail.com",Password = "pavan12",CreatedDate = DateTime.Now,UpdatedDate = null,IsActive = true}
            };
            context.TblUserDetails.AddRange(user);
            context.SaveChanges();
            var user1 = new List<TblRoom>()
            {
                new TblRoom(){RoomId = 1,UserId = 2,RoomName = "FunGame",NumOfPeopele = 8,CheckIn = DateTime.Now,Updated = null,IsActive = true},
                new TblRoom(){RoomId = 2,UserId = 2,RoomName = "TextGame",NumOfPeopele = 10,CheckIn = DateTime.Now,Updated = null,IsActive = true}
            };
            context.TblRooms.AddRange(user1);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
