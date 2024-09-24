using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShareAThought;

public partial class DyslexicoContext : DbContext
{
    public DyslexicoContext()
    {
    }

    public DyslexicoContext(DbContextOptions<DyslexicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=dyslexico-test.database.windows.net;Database=dyslexico;User Id=CloudSAe7d9f51e;Password=Reading@365;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>(entity =>
        {
            entity.HasKey(e => e.AuthorId).HasName("PK__Author__86516BCF1ABD1089");

            entity.ToTable("Author");

            entity.HasIndex(e => e.Username, "UQ__Author__F3DBC5728DD23159").IsUnique();

            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Note>(entity =>
        {
            entity.HasKey(e => e.NoteId).HasName("PK__Note__CEDD0FA451344420");

            entity.ToTable("Note");

            entity.HasIndex(e => new { e.AuthorId, e.Title }, "UQ__Note__B803CA75EAF14B25").IsUnique();

            entity.Property(e => e.NoteId).HasColumnName("note_id");
            entity.Property(e => e.AuthorId).HasColumnName("author_id");
            entity.Property(e => e.Body)
                .HasColumnType("text")
                .HasColumnName("body");
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("title");

            entity.HasOne(d => d.Author).WithMany(p => p.Notes)
                .HasForeignKey(d => d.AuthorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Note__author_id__6C190EBB");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
