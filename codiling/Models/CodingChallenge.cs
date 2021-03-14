using System;
using System.Collections.Generic;

#nullable disable

namespace codiling.Models
{
    public partial class CodingChallenge
    {
        public CodingChallenge()
        {
            Submissions = new HashSet<Submission>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Submission> Submissions { get; set; }
    }
}
