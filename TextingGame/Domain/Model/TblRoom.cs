namespace Domain;

public partial class TblRoom
{
    public int RoomId { get; set; }

    public int? UserId { get; set; }

    public string? RoomName { get; set; }

    public int? NumOfPeopele { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblMessage> TblMessages { get; } = new List<TblMessage>();

    public virtual ICollection<TblUserRoom> TblUserRooms { get; } = new List<TblUserRoom>();

    public virtual TblUserDetail? User { get; set; }
}
