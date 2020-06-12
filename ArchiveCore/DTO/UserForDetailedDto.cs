using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveCore.DTO
{
    public class UserForDetailedDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public int Age { get; set; } 
        public DateTime Created { get; set; }
        public DateTime LastActive { get; set; }    
        public string Country { get; set; }         
    }
}
