﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountGui
{
    public class AccountException : Exception
    {
        public AccountException(AccountExceptionType reason) : base(reason.ToString())
        {
        }
    }
}
