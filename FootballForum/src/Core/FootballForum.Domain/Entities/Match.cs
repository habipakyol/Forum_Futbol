using FootballForum.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FootballForum.Domain.Entities
{
    public class Match : BaseEntity
    {
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public DateTime MatchDate { get; set; }
        public int? HomeScore { get; set; }
        public int? AwayScore { get; set; }
        public string Stadium { get; set; }
        public virtual Team? HomeTeam { get; set; }
        public virtual Team? AwayTeam { get; set; }
        public virtual ICollection<Comment>? MatchComments { get; set; }
    }
}
