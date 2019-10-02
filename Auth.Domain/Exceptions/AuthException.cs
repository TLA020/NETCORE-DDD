using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace Auth.Domain.Exceptions
{
    public class AuthException : Exception
    {
        public AuthException() : base() { }

        public AuthException(string message) : base(message) { }

        public AuthException(string message, params object[] args)
            : base(String.Format(CultureInfo.CurrentCulture, message, args))
        {
        }
    }
}
