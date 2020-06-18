using System;
using System.ComponentModel.DataAnnotations;

namespace ArchiveCore.DTO
{
    public class UserForUpdateDto
    {
        public Guid Id { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 20 characters")]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 20 characters")]

        public string Password { get; set; }
        [Required(ErrorMessage = "Confirm Password is required"), Compare("Password")]

        public string ConfirmPassword { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        public string City { get; set; }

        public DateTime Created { get; set; }

        public DateTime LastActive { get; set; }
    }
}
