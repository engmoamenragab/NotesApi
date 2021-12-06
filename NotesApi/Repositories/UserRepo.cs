using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using NotesApi.Context;
using NotesApi.Interfaces;
using NotesApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace NotesApi.Repositories
{
    public class UserRepo : IUserRepo
    {
        #region Fields
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;
        private readonly IConfiguration configuration;
        #endregion

        #region Constructors
        public UserRepo(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }
        #endregion

        #region Methods
        public async Task<IdentityResult> Signup(Signup model)
        {
                var newUser = new User()
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    UserName = model.Email,
                    Age = model.Age,
                };
                return await userManager.CreateAsync(newUser, model.Password);
        }

        public async Task<string> Signin(Signin model)
        {
            var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if(!result.Succeeded)
            {
                return null;
            }
            var user = await userManager.FindByEmailAsync(model.Email);
            var authClaims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sid, user.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            var authSigninKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JWT:Secret"]));
            var token = new JwtSecurityToken
            (
                issuer: configuration["JWT:ValidIssuer"],
                audience: configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddDays(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigninKey, SecurityAlgorithms.HmacSha256Signature)
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        #endregion
    }
}
