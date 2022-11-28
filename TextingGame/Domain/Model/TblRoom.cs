using System;
using System.Collections.Generic;

namespace Persistence;

public partial class TblRoom
{
    public int RoomId { get; set; }

    public int? UserId { get; set; }

    public string? RoomName { get; set; }

    public int? NumOfPeopele { get; set; }

    public DateTime? CheckIn { get; set; }

    public DateTime? Updated { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblUserDetail? User { get; set; }
}
