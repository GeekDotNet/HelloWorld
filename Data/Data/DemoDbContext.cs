using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data
{
    public partial class DemoDbContext : DbContext
    {
        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ClaimAttachments> ClaimAttachments { get; set; }
        public virtual DbSet<ClaimNotes> ClaimNotes { get; set; }
        public virtual DbSet<ClaimsInfo> ClaimsInfo { get; set; }
        public virtual DbSet<Codes> Codes { get; set; }
        public virtual DbSet<FileErrors> FileErrors { get; set; }
        public virtual DbSet<UploadedFiles> UploadedFiles { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=DemoDb;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<ClaimAttachments>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK_Attachments_ClaimId");

                entity.Property(e => e.ClaimId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.Claim)
                    .WithOne(p => p.ClaimAttachments)
                    .HasForeignKey<ClaimAttachments>(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClaimAtta__Claim__286302EC");
            });

            modelBuilder.Entity<ClaimNotes>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK_ClaimNotes_ClaimId");

                entity.Property(e => e.ClaimId).ValueGeneratedNever();

                entity.Property(e => e.CreatedBy)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.CreatedDate).HasColumnType("date");

                entity.Property(e => e.Notes)
                    .IsRequired()
                    .HasMaxLength(500);

                entity.HasOne(d => d.Claim)
                    .WithOne(p => p.ClaimNotes)
                    .HasForeignKey<ClaimNotes>(d => d.ClaimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ClaimNote__Claim__2B3F6F97");
            });

            modelBuilder.Entity<ClaimsInfo>(entity =>
            {
                entity.HasKey(e => e.ClaimId)
                    .HasName("PK_ClaimsInfo_ClaimId");

                entity.Property(e => e.ClaimId).ValueGeneratedNever();

                entity.Property(e => e.ActionTimeStamp).HasColumnType("date");

                entity.Property(e => e.Amount).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.Description).HasMaxLength(50);

                entity.Property(e => e.Processedon).HasColumnType("date");

                entity.Property(e => e.ReceivedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Remarks).HasMaxLength(250);

                entity.Property(e => e.Source)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10);
            });

            modelBuilder.Entity<Codes>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("PK_Codes_code");

                entity.Property(e => e.Code)
                    .HasMaxLength(6)
                    .ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<FileErrors>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK_FileErrors_ClaimId");

                entity.Property(e => e.FileId).ValueGeneratedNever();

                entity.Property(e => e.ErrorCode).HasMaxLength(6);

                entity.HasOne(d => d.ErrorCodeNavigation)
                    .WithMany(p => p.FileErrors)
                    .HasForeignKey(d => d.ErrorCode)
                    .HasConstraintName("FK__FileError__Error__32E0915F");

                entity.HasOne(d => d.File)
                    .WithOne(p => p.FileErrors)
                    .HasForeignKey<FileErrors>(d => d.FileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileError__FileI__31EC6D26");
            });

            modelBuilder.Entity<UploadedFiles>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PK_UploadedFiles_FileId");

                entity.Property(e => e.FileId).ValueGeneratedNever();

                entity.Property(e => e.ActionTimestamp)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FileName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.FileStatus)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.UploadedBy)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.UploadedDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });
        }
    }
}
