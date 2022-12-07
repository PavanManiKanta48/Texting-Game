using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GuessUser
{
    public class CreateGuessUserRequestModel
    {
        public int? UserId { get; set; }
        public int ImpersonatedUserId { get; set; }
    }
}
