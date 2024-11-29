using FootballForum.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FootballForum.Domain.Entities
{
    // FootballForum.Domain/Entities/Comment.cs
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public Guid? PostId { get; set; }
        public Guid? MatchId { get; set; }
        public virtual Post? Post { get; set; }
        public virtual Match? Match { get; set; }
    }

}
