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
        modelBuilder.Entity<Author>()
            .HasKey(a => a.AuthorId);

        modelBuilder.Entity<Author>()
            .HasIndex(a => a.Username)
            .IsUnique();

        modelBuilder.Entity<Note>()
            .HasKey(n => n.NoteId);

        modelBuilder.Entity<Note>()
            .HasIndex(a => a.Title)
            .IsUnique();
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
