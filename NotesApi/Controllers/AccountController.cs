using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NotesApi.Interfaces;
using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        #region Fields
        private readonly ILogger<AccountController> logger;
        private readonly IUserRepo user;
        #endregion

        #region Constructors
        public AccountController(ILogger<AccountController> logger, IUserRepo user)
        {
            this.logger = logger;
            this.user = user;
        }
        #endregion

        #region Actions
        [HttpPost]
        [Route("~/api/Account/Signup")]
        public async Task<IActionResult> Signup([FromBody] Signup newUser)
        {
            var result = await user.Signup(newUser);
            if(result.Succeeded)
            {
                return Ok(new Response()
                {
                    Code = "200",
                    Status = "Ok",
                    Message = "User Registered"
                });
            }
            return Unauthorized(new Response()
            {
                Code = "401",
                Status = "Unauthorized",
                Message = "Unauthorized User"
            });
        }

        [HttpPost]
        [Route("~/api/Account/Signin")]
        public async Task<IActionResult> Signin([FromBody] Signin existUser)
        {
            var result = await user.Signin(existUser);
            if (string.IsNullOrEmpty(result))
            {
                return Unauthorized(new Response()
                {
                    Code = "401",
                    Status = "Unauthorized",
                    Message = "Unauthorized User"
                });
            }
            return Ok(new Response()
            {
                Code = "200",
                Status = "Ok",
                Message = "Success",
                Token = result
            });
        }
        #endregion
    }
}
