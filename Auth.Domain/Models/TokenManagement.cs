using System;
using System.Collections.Generic;
using System.Text;

namespace Auth.Domain.Models
{
    public class TokenManagement
    {
        public string Secret { get; set; }

        public string Issuer { get; set; }

        public string Audience { get; set; }

        public int AccessExpiration { get; set; }

        public int RefreshExpiration { get; set; }
    }
}
