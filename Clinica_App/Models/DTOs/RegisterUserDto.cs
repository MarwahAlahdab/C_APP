using System;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Clinica_App.Models.DTOs
{
	public class RegisterUserDto
	{
        [Required(ErrorMessage = "You have missed to fill the username")]
        [Display(Name = "User Name")]
        [MinLength(3)]
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public string PhoneNumber { get; set; }


    }
}

