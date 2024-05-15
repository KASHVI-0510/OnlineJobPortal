using System;
using System.Collections.Generic;

namespace OnlineJobPortal.Models;

public partial class ViewResume
{
    public int Id { get; set; }

    public string CompanyName { get; set; } = null!;

    public string JobTitle { get; set; } = null!;

    public string UserName { get; set; } = null!;

    public string UserEmail { get; set; } = null!;

    public long MobileNo { get; set; }
}
