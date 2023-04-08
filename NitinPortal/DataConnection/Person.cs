using System;
using System.Collections.Generic;

namespace NitinPortal.DataConnection;

public partial class Person
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int? Salary { get; set; }

    public string? Gender { get; set; }

    public int? DepartmentId { get; set; }
}
