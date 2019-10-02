
using Auth.Domain.Exceptions;
using Auth.Domain.Models;
using Auth.infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Auth.API.Services
{
    public class UserService : IUserService
    {
        private readonly AuthContext _context;
        private readonly IPasswordService _passwordService;

        public UserService(AuthContext context, IPasswordService passwordService)
        {
            _context = context;
            _passwordService = passwordService;
        }

        public bool IsValidUser(TokenRequest tokenRequest)
        {
            var user = _context.Users.SingleOrDefault(x => x.Username == tokenRequest.Username);

            if (user == null)
            {
                throw new AuthException("User not found");
            }

            if (!_passwordService.VerifyPasswordHash(tokenRequest.Password, user.PasswordHash, user.PasswordSalt))
            {
                throw new AuthException("Password wrong");
            }

            return true;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.Users;
        }

        public User GetById(Guid id)
        {
            return _context.Users.Find(id);
        }

        public User Create(User user)
        {
            if (string.IsNullOrWhiteSpace(user.Password))
            {
                throw new AuthException("Password is required");
            }

            if (_context.Users.Any(x => x.Username == user.Username))
            {
                throw new AuthException($"Username {user.Username} is already taken");
            }

            _passwordService.CreatePasswordHash(user.Password, out byte[] passwordHash, out byte[] passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }

        public void Update(User editedUser)
        {
            var originalUser = _context.Users.Find(editedUser.Id);

            if (originalUser == null)
            {
                throw new AuthException("User not found");
            }

            if (originalUser.Username != editedUser.Username) //username change requested?
            {
                if (_context.Users.Any(x => x.Username == editedUser.Username))
                {
                    throw new AuthException("Username " + editedUser.Username + " is already taken");
                }
            }

            if (!string.IsNullOrWhiteSpace(editedUser.Password))
            {
               _passwordService.CreatePasswordHash(editedUser.Password, out byte[] passwordHash, out byte[] passwordSalt);

               
                editedUser.PasswordHash = passwordHash;
                editedUser.PasswordSalt = passwordSalt;
            }

            _context.Users.Update(editedUser);
            _context.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return;
            }
          throw new AuthException("User not found");
        }
      
    }
}
