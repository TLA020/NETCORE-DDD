using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Auth.API.Services;
using Auth.Domain.Models;
using AutoMapper;
using Auth.API.ViewModels;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Auth.API.Helpers;
using Microsoft.Extensions.Options;
using Auth.Domain.Exceptions;

namespace Auth.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        private readonly ITokenService _tokenService;

        public UsersController(IUserService userService, IMapper mapper,  ITokenService tokenService)
        {
            _userService = userService;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]TokenRequest tokenRequest)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (_tokenService.IsAuthenticated(tokenRequest, out string token))
                {
                    return Ok(token);
                }

                return Unauthorized();
            }
            catch (AuthException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]User user)
        {
            try
            {
                _userService.Create(user);
                return Ok();
            }
            catch (AuthException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            var response = _mapper.Map<List<UserViewModel>>(users);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            var res = _mapper.Map<UserViewModel>(user);
            return Ok(res);
        }

        [HttpPut("{id}")]
        public IActionResult Update([FromBody]User user)
        {
            try
            {
                // save 
                _userService.Update(user);
                return Ok("User updated");
            }
            catch (AuthException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}