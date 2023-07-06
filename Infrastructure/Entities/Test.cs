using System;
using System.Collections.Generic;

namespace Infrastructure.Entities;

public partial class Test
{
    public long Serial { get; set; }

    public string? Associationtype { get; set; }

    public string? Branchtype { get; set; }

    public string? Financialcode { get; set; }

    public string? Postalcode { get; set; }

    public string? County { get; set; }

    public string? Address { get; set; }

    public string? Telepon { get; set; }
}
