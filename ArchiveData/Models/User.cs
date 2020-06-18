using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArchiveData.Models
{
    public class User : IdentityUser<Guid>
    {   
        public string Country { get; set; }
        public int Age { get; set; }
        public DateTime LastActive { get; set; }
        public DateTime Created { get; set; }
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
