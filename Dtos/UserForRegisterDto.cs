using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.API.Dtos
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }
        
        public string Username { get; set; }
        [Required]
        [StringLength(8, ErrorMessage = "You must enter at least 8 symbols", MinimumLength = 4)]
        public string Password { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string KnownAs { get; set; }
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string Country { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }

    }
}
