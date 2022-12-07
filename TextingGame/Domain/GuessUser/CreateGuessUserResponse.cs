using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GuessUser
{
    public class CreateGuessUserResponse:BaseResponseModel
    {
        public CreateGuessUserRequestModel createGuessUserResponse { get; set; }
    }
}
