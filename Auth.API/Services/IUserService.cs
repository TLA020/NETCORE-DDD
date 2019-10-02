using Auth.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Auth.API.Services
{
    public interface IUserService
    {
        bool IsValidUser(TokenRequest tokenRequest);
        IEnumerable<User> GetAll();
        User GetById(Guid id);
        User Create(User user);
        void Update(User user);
        void Delete(Guid id);
    }
}
