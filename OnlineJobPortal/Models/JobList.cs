using System;
using System.Collections.Generic;

namespace OnlineJobPortal.Models;

public partial class JobList
{
    public string JobTitle { get; set; } = null!;

    public int NoOfPost { get; set; }

    public string QualificationReqiured { get; set; } = null!;

    public int ExperienceReqiured { get; set; }

    public string Company { get; set; } = null!;

    public string Country { get; set; } = null!;

    public string State { get; set; } = null!;
}
