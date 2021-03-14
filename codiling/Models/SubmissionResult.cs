using System;
using System.Collections.Generic;

#nullable disable

namespace codiling.Models
{
    public partial class SubmissionResult
    {
        public string UserName { get; set; }
        public int SuccessSolutions { get; set; }
        public string Tasks { get; set; }
    }
}
