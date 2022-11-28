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
                new TblUserDetail(){UserId = 22,UserName = "Anshika",EmailId = "anshika@gmail.com",Password = "anshi12",CreatedDate = DateTime.Now,UpdatedDate = null,IsActive = true},
                new TblUserDetail(){UserId = 23,UserName = "Pavan",EmailId = "pavan@gmail.com",Password = "pavan12",CreatedDate = DateTime.Now,UpdatedDate = null,IsActive = true}
            };
            context.TblUserDetails.AddRange(user);
            context.SaveChanges();
        }
        public void Dispose()
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
