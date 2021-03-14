using System;
using System.Collections.Generic;

#nullable disable

namespace codiling.Models
{
    public partial class SubmissionResult
    {
        public int IdSubmission { get; set; }
        public string UserName { get; set; }
        public decimal Result { get; set; }

        public virtual Submission IdSubmissionNavigation { get; set; }
    }
}
