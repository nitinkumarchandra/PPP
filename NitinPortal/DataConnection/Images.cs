using System;
using System.Collections.Generic;

namespace NitinPortal.DataConnection;

public partial class Images
{
    public int ImageId { get; set; }

    public string? Name { get; set; }

    public string? Extension { get; set; }

    public string? FilePath { get; set; }

    public string? FileSize { get; set; }

    public string? FileType { get; set; }
}
