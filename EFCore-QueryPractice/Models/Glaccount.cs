using System;
using System.Collections.Generic;

namespace EFCore_QueryPractice.Models;

public partial class Glaccount
{
    public int AccountNo { get; set; }

    public string AccountDescription { get; set; } = null!;

    public virtual ICollection<InvoiceLineItem> InvoiceLineItems { get; set; } = new List<InvoiceLineItem>();

    public virtual ICollection<Vendor> Vendors { get; set; } = new List<Vendor>();
}
