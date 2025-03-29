using System;
using System.Collections.Generic;

namespace DriverDB1.Venom;

public partial class Photo
{
    public int Id { get; set; }

    public byte[]? Photo1 { get; set; }

    public virtual Driver? Driver { get; set; }
}
