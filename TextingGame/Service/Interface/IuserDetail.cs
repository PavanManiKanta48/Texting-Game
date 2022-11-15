using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
   public interface IuserDetail
    {
        List<TblUserDetail> GetUser();
        bool Register(TblUserDetail tblUser);
        bool UpdateUserDetail(TblUserDetail tblUser);
        bool DeleteUserDetail(TblUserDetail tblUser);
    }
}
