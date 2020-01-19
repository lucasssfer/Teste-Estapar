using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Estapar.Models
{
    public partial class EstaparContext : DbContext
    {
        public EstaparContext()
        {
        }

        public EstaparContext(DbContextOptions<EstaparContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Manobra> Manobra { get; set; }
        public virtual DbSet<Manobrista> Manobrista { get; set; }
        public virtual DbSet<Veiculo> Veiculo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manobra>(entity =>
            {
                entity.Property(e => e.DataManobra)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Manobrista)
                    .WithMany(p => p.Manobra)
                    .HasForeignKey(d => d.ManobristaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manobra_Manobrista");

                entity.HasOne(d => d.Veiculo)
                    .WithMany(p => p.Manobra)
                    .HasForeignKey(d => d.VeiculoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Manobra_Veiculo");
            });

            modelBuilder.Entity<Manobrista>(entity =>
            {
                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(14)
                    .IsUnicode(false);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Veiculo>(entity =>
            {
                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Placa)
                    .HasMaxLength(7)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
