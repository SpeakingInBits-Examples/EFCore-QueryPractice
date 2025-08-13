using System;
using System.Collections.Generic;

namespace EFCore_QueryPractice.Models;

public partial class Term
{
    public int TermsId { get; set; }

    public string TermsDescription { get; set; } = null!;

    public short TermsDueDays { get; set; }

    public virtual ICollection<Invoice> Invoices { get; set; } = new List<Invoice>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
