namespace Persistence;

public partial class TblUserRoom
{
    public int PersonId { get; set; }

    public int? RoomId { get; set; }

    public int? UserId { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblRoom? Room { get; set; }

    public virtual TblUserDetail? User { get; set; }
}
