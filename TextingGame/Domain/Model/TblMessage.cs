namespace Domain;

public partial class TblMessage
{
    public int MessageId { get; set; }

    public int? RoomId { get; set; }

    public int? UserId { get; set; }

    public string? Message { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual TblRoom? Room { get; set; }

    public virtual TblUserDetail? User { get; set; }
}
