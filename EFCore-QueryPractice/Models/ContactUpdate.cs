using System;
using System.Collections.Generic;

namespace EFCore_QueryPractice.Models;

public partial class ContactUpdate
{
    public int VendorId { get; set; }

    public string? LastName { get; set; }

    public string? FirstName { get; set; }
}
