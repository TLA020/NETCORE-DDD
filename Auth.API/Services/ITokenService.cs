using Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.API.Services
{
    public interface ITokenService
    {
        bool IsAuthenticated(TokenRequest request, out string token);
    }
}
