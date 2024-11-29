using FootballForum.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballForum.Domain.Entities
{
    // FootballForum.Domain/Entities/Post.cs
    public class Post : BaseEntity
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid TeamId { get; set; }
        public virtual Team? Team { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
    }
}
