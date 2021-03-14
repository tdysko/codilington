using System;
using System.Collections.Generic;

#nullable disable

namespace codiling.Models
{
    public partial class Submission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IdCodingChallenges { get; set; }
        public string Solution { get; set; }

        public virtual CodingChallenge IdCodingChallengesNavigation { get; set; }
    }
}
