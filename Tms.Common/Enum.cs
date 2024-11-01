using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Tms.Core
{
    public enum ApprovalStatus
    {


        [Description("Pending")]
        Pending = 1,

        [Description("Approved")]
        Approved = 2,

        [Description("Rejected")]
        Rejected = 3,

    }
}
