using System;
using System.Collections.Generic;

namespace sample.Models;

public partial class AppointmentTable
{
    public int AppointmentId { get; set; }

    public string PatientName { get; set; } = null!;

    public string MedicalIssue { get; set; } = null!;

    public string DoctorToVisit { get; set; } = null!;

    public string DoctorAvailableTime { get; set; } = null!;

    public DateTime AppointmentTime { get; set; }

    public virtual Disease MedicalIssueNavigation { get; set; } = null!;
}
