using System;
using System.Collections.Generic;

namespace sample.Models;

public partial class DoctorDetail
{
    public int DoctorId { get; set; }

    public string Name { get; set; } = null!;

    public string Specialised { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
}
