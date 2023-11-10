using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SegurosAgro.Models
{
    public partial class AgroSegurosContext : DbContext
    {
        public AgroSegurosContext()
        {
        }

        public AgroSegurosContext(DbContextOptions<AgroSegurosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asegurado> Asegurados { get; set; } = null!;
        public virtual DbSet<AsignaciónSeguro> AsignaciónSeguros { get; set; } = null!;
        public virtual DbSet<Seguro> Seguros { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-2OMOI66\\SQLEXPRESS;Initial Catalog=AgroSeguros;user id=sa;password=12345678;TrustServerCertificate=True;Encrypt=false");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Asegurado>(entity =>
            {
                entity.HasKey(e => e.IdAsegurado)
                    .HasName("PK__asegurad__E7FDBA99F4049789");

                entity.ToTable("asegurados");

                entity.Property(e => e.IdAsegurado).HasColumnName("id_asegurado");

                entity.Property(e => e.Cedula).HasColumnName("cedula");

                entity.Property(e => e.Edad).HasColumnName("edad");

                entity.Property(e => e.NombreCliente)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nombreCliente");

                entity.Property(e => e.Telefono).HasColumnName("telefono");
            });

            modelBuilder.Entity<AsignaciónSeguro>(entity =>
            {
                entity.HasKey(e => e.IdAsignación)
                    .HasName("PK__asignaci__C3EBCA43FA442678");

                entity.ToTable("asignaciónSeguros");

                entity.Property(e => e.IdAsignación).HasColumnName("id_asignación");

                entity.Property(e => e.IdAsegurado).HasColumnName("id_asegurado");

                entity.Property(e => e.IdSeguros).HasColumnName("id_seguros");

                entity.HasOne(d => d.IdAseguradoNavigation)
                    .WithMany(p => p.AsignaciónSeguros)
                    .HasForeignKey(d => d.IdAsegurado)
                    .HasConstraintName("FK__asignació__id_as__403A8C7D");

                entity.HasOne(d => d.IdSegurosNavigation)
                    .WithMany(p => p.AsignaciónSeguros)
                    .HasForeignKey(d => d.IdSeguros)
                    .HasConstraintName("FK__asignació__id_se__3F466844");
            });

            modelBuilder.Entity<Seguro>(entity =>
            {
                entity.HasKey(e => e.IdSeguros)
                    .HasName("PK__seguro__75503AEC22B82291");

                entity.ToTable("seguro");

                entity.Property(e => e.IdSeguros).HasColumnName("id_seguros");

                entity.Property(e => e.CodigoSeguro)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("codigoSeguro");

                entity.Property(e => e.NombreSeguro)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombreSeguro");

                entity.Property(e => e.Prima)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("prima");

                entity.Property(e => e.SumaAsegurada)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("sumaAsegurada");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
