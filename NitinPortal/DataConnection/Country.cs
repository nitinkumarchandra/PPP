using System;
using System.Collections.Generic;

namespace NitinPortal.DataConnection;

public partial class Country
{
    public int CountryId { get; set; }

    public string? CountryName { get; set; }

    public virtual ICollection<State> States { get; } = new List<State>();
}
