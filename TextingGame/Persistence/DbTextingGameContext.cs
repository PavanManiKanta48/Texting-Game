using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence;

public partial class DbTextingGameContext : DbContext
{
    public DbTextingGameContext()
    {
    }

    public DbTextingGameContext(DbContextOptions<DbTextingGameContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TblMessage> TblMessages { get; set; }

    public virtual DbSet<TblRoom> TblRooms { get; set; }

    public virtual DbSet<TblUserDetail> TblUserDetails { get; set; }

    public virtual DbSet<TblUserRoom> TblUserRooms { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server = 65.0.181.176;Database=db_TextingGame;User Id = admin;Password = Asdf1234*;TrustServerCertificate=True;Connection Timeout=300;command timeout=300");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TblMessage>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PK__tbl_Mess__C87C0C9C1B328ADD");

            entity.ToTable("tbl_Messages");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Room).WithMany(p => p.TblMessages)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__tbl_Messa__RoomI__5CD6CB2B");

            entity.HasOne(d => d.User).WithMany(p => p.TblMessages)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tbl_Messa__UserI__5DCAEF64");
        });

        modelBuilder.Entity<TblRoom>(entity =>
        {
            entity.HasKey(e => e.RoomId).HasName("PK__tbl_Room__32863939EB69B0A8");

            entity.ToTable("tbl_Rooms");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.RoomName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.TblRooms)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tbl_Rooms__UserI__5629CD9C");
        });

        modelBuilder.Entity<TblUserDetail>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__tbl_User__1788CC4C7D3D9148");

            entity.ToTable("tbl_UserDetails");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.EmailId)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MobileNo)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");
            entity.Property(e => e.UserName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TblUserRoom>(entity =>
        {
            entity.HasKey(e => e.PersonId).HasName("PK__tbl_User__AA2FFBE513552B43");

            entity.ToTable("tbl_User_Rooms");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.UpdatedDate).HasColumnType("datetime");

            entity.HasOne(d => d.Room).WithMany(p => p.TblUserRooms)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK__tbl_User___RoomI__59063A47");

            entity.HasOne(d => d.User).WithMany(p => p.TblUserRooms)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__tbl_User___UserI__59FA5E80");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
