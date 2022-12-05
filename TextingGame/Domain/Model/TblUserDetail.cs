namespace Persistence;

public partial class TblUserDetail
{
    public int UserId { get; set; }

    public string? UserName { get; set; }

    public string? EmailId { get; set; }

    public string? Password { get; set; }

    public string? MobileNo { get; set; }

    public DateTime? CreatedDate { get; set; }

    public DateTime? UpdatedDate { get; set; }

    public bool? IsActive { get; set; }

    public virtual ICollection<TblMessage> TblMessages { get; } = new List<TblMessage>();

    public virtual ICollection<TblRoom> TblRooms { get; } = new List<TblRoom>();

    public virtual ICollection<TblUserRoom> TblUserRooms { get; } = new List<TblUserRoom>();
}
