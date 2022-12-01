using System;
using System.Collections.Generic;

namespace Persistence;

public partial class TblUserRoom 
{
    public int PersonId { get; set; }

    public int? RoomIdFk { get; set; }

    public int? UserId { get; set; }

    public DateTime? EnterDate { get; set; }

    public DateTime? ExitDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblRoom? RoomIdFkNavigation { get; set; }

    public virtual TblUserDetail? User { get; set; }
}
