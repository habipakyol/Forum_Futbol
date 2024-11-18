using FootballForum.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FootballForum.Domain.Entities
{
    public class Team : BaseEntity
    {
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Logo { get; set; }
        public string City { get; set; }
        public DateTime EstablishmentDate { get; set; }
        public string StadiumName { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
        public virtual ICollection<Match> HomeMatches { get; set; }
        public virtual ICollection<Match> AwayMatches { get; set; }
    }
}
