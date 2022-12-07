using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.GuessUser
{
    public class ListOfResultResponse:BaseResponseModel
    {
        public List<ListOfResultResponse> listOfResultResponses { get; set; }
    }
}
