using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ArchiveCore.DTO
{
    public class UserForRegisterDto
    {
        public UserForRegisterDto()
        {
            Created = DateTime.Now;
            LastActive = DateTime.Now;
        }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify username between 4 and 20 characters")]
        public string Username { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 20 characters")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required"), Compare("Password")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "You must specify City between 3 and 20 characters")]
        public string City { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }
    }
}
