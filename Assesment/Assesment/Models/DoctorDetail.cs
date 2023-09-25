using System;
using System.Collections.Generic;

namespace Assesment.Models;

public  class DoctorDetail
{
    public int DoctorId { get; set; }

    public string Name { get; set; }

    public string Specialised { get; set; }

    public string Qualification { get; set; }

    public TimeSpan StartTime { get; set; }

    public TimeSpan EndTime { get; set; }

    public virtual ICollection<Disease> Diseases { get; set; } = new List<Disease>();
}
