using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserModel
{
    public class PostLoginUserRequestModel
    {
        public string? EmailId { get; set; }
        public string? Password { get; set; }
    }
}
