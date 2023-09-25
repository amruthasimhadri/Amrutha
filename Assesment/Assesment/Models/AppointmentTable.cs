using System;
using System.Collections.Generic;

namespace Assesment.Models;

public class AppointmentTable
{
    public int AppointmentId { get; set; }

    public string PatientName { get; set; }

    public string MedicalIssue { get; set; }

    public string DoctorToVisit { get; set; }

    public string DoctorAvailableTime { get; set; }

    public DateTime AppointmentTime { get; set; }

    public virtual Disease MedicalIssueNavigation { get; set; }
}
