using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FootballForum.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<Guid>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? ProfilePicture { get; set; }
        public DateTime LastLogin { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
    }
}
