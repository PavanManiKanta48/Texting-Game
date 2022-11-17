using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IEncryptServices
    {
        string EncodePasswordToBase64(string password);
        string DecodeFrom64(string encodedData);
    }
}