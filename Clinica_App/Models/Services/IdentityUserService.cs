using System;
using Clinica_App.Data;
using Clinica_App.Models.DTOs;
using Clinica_App.Models.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;


namespace Clinica_App.Models.Services
{
    public class IdentityUserService : IUser
    {


        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private readonly ClinicaDbContext _dbContext;


        public IdentityUserService(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ClinicaDbContext dbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _dbContext = dbContext;
        }

        public async Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState)
        {
            var user = new ApplicationUser
            {
                UserName = data.username ,
                Email = data.email ,
                PhoneNumber = data.PhoneNumber
            };

            var result = await _userManager.CreateAsync(user, data.password);

            if (result.Succeeded)
            {
            
                await _signInManager.SignInAsync(user, isPersistent: false);

        
                var userDto = new UserDto
                {
                    Id = user.Id,
                    Username = user.UserName
                };

                return userDto;
            }

 
            foreach (var error in result.Errors)
            {
                modelState.AddModelError("", error.Description);
            }

            return null;
        }









        public async Task<UserDto> Authenticate(string username, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(username, password, true, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(username);

                return new UserDto()
                {
                    Id = user.Id,
                    Username = user.UserName,
                };
            }


            return null;
        }

        public async Task<UserDto> GetUSer(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            return new UserDto
            {
                Id = user.Id,
                Username = user.UserName,
            };
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }
    }
}