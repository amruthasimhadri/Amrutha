using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class DoctorDetail
{
    public int DoctorId { get; set; }

    public string Name { get; set; } = null!;

    public string Specialised { get; set; } = null!;

    public string Qualification { get; set; } = null!;

    public TimeOnly StartTime { get; set; }

    public TimeOnly EndTime { get; set; }

    public virtual ICollection<Disease> Diseases { get; } = new List<Disease>();
}
