using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Clinica_App.Models.DTOs;
using Clinica_App.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Clinica_App.Controllers
{
    public class AuthController : Controller
    {

        private readonly IUser _userService;

        public AuthController(IUser userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.Register(model, ModelState);

            if (result != null)
            {
                // Registration successful
                // You might redirect the user to a dashboard or home page
                return RedirectToAction("Index", "Home"); // Change this according to your application flow
            }

            // If registration fails, return back to the registration view with errors
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var result = await _userService.Authenticate(model.Username, model.Password);

            if (result != null)
            {
               
                return RedirectToAction("Index", "Home"); // C
            }

            // If login fails, return back to the login view with errors
            ModelState.AddModelError("", "Invalid username or password");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();

           
            return RedirectToAction("Index", "Home"); 
        }


    }
}