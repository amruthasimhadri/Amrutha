using System;
using System.Collections.Generic;

namespace DataAccess.Models;

public partial class Disease
{
    public int DiseasesId { get; set; }

    public string DiseasesName { get; set; } = null!;

    public int SuitableDoctor { get; set; }

    public virtual ICollection<AppointmentTable> AppointmentTables { get; } = new List<AppointmentTable>();

    public virtual DoctorDetail SuitableDoctorNavigation { get; set; } = null!;
}
