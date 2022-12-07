using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.UserModel
{
    public class PostUserRequestmodel
    {
        public string? UserName { get; set; }

        public string EmailId { get; set; } = null!;

        public string? Password { get; set; }

        public string? MobileNo { get; set; }
        public string? ConfirmPassword { get; set; }
    }
}
