using System;
using System.Collections.Generic;

namespace Persistence;

public partial class TblRoom
{
    public int RoomId { get; set; }

    public int? UserId { get; set; }

    public string? RoomName { get; set; }

    public long? NumOfPeopele { get; set; }

    public DateTime? RoomTime { get; set; }

    public string? IsActive { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public virtual TblUserDetail? User { get; set; }
}
