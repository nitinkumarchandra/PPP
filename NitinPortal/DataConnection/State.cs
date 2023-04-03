using System;
using System.Collections.Generic;

namespace NitinPortal.DataConnection;

public partial class State
{
    public int StateId { get; set; }

    public string? StateName { get; set; }

    public int? CountryId { get; set; }

    public virtual ICollection<City> Cities { get; } = new List<City>();

    public virtual Country? Country { get; set; }
}
