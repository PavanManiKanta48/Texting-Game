﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IEncrypt
    { 
        string Decrypt_Password(string encodedData);
    }
}