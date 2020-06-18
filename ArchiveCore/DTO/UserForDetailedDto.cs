using System;

namespace ArchiveCore.DTO
{
    public class UserForDetailedDto
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
