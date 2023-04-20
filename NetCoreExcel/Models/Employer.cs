using System;
using System.Collections.Generic;

namespace NetCoreExcel.Models;

public partial class Employer
{
    public int EmployerId { get; set; }

    public string? Name { get; set; }

    public DateTime? CreatedOn { get; set; }

    public virtual ICollection<AppUser> Users { get; set; } = new List<AppUser>();
}
