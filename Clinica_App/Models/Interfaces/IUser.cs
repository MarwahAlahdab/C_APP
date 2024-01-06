using System;
using Clinica_App.Models.DTOs;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Clinica_App.Models.Interfaces
{
	public interface IUser
	{

        public Task<UserDto> Register(RegisterUserDto data, ModelStateDictionary modelState);
        public Task<UserDto> Authenticate(string username, string password);
        public Task<UserDto> GetUSer(string username);
        Task Logout();
    }
}

