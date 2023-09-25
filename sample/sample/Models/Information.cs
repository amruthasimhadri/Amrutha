using System;
using System.Collections.Generic;

namespace sample.Models;

public partial class Information
{
    public string CustomerName { get; set; } = null!;

    public string? Address { get; set; }

    public DateTime? LoanStartedDate { get; set; }

    public DateTime? DueDate { get; set; }

    public decimal? Principal { get; set; }

    public decimal? RateOfInterest { get; set; }

    public decimal? NoOfYears { get; set; }

    public decimal? CalculatedAmount { get; set; }
}
