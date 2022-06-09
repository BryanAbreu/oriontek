using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace oriontek.Models
{
    public partial class oriontekContext : DbContext
    {
        public oriontekContext()
        {
        }

        public oriontekContext(DbContextOptions<oriontekContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Direccion> Direccions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-UVCT3DV\\SQLEXPRESS;Database=oriontek;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasKey(e => e.Idclient);

                entity.ToTable("client");

                entity.Property(e => e.Idclient).HasColumnName("idclient");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(e => e.Iddirecc);

                entity.ToTable("direccion");

                entity.Property(e => e.Iddirecc).HasColumnName("iddirecc");

                entity.Property(e => e.Direccion1)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("direccion");

                entity.Property(e => e.Idcli).HasColumnName("idcli");

                entity.HasOne(d => d.IdcliNavigation)
                    .WithMany(p => p.Direccions)
                    .HasForeignKey(d => d.Idcli)
                    .HasConstraintName("FK_direccion_client");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
