using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
   public interface IRoomServices
    {
        List<TblRoom> GetRoom();
        bool CheckExistUserId(TblRoom room);
        void CreateRoom(TblRoom croom);
        bool CheckExistRoomId(TblRoom room);
        void UpdateRoom(TblRoom uroom);
        void DeleteRoom(TblRoom droom);
    }
}
