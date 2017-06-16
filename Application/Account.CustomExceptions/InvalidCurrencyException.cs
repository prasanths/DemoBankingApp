﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Account.CustomExceptions
{
    public class InvalidCurrencyException : Exception
    {
        public InvalidCurrencyException(string message) : base(message)
        {
        }

        public InvalidCurrencyException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
