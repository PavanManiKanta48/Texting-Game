using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
   public interface IMessageServices
    {
        List<TblMessage> GetMessages();
        bool CheckUserId(TblMessage message);
        bool CheckRoomId(TblMessage message);
        bool AddMessages(TblMessage message);
    }
}
