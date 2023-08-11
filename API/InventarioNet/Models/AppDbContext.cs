using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace InventarioNet.Models 
{
    //public partial class AppDbContext : DbContext
    //{
    //    public AppDbContext()
    //    {
    //    }

    //    public AppDbContext(DbContextOptions<AppDbContext> options)
    //        : base(options)
    //    {
    //    }

    //    public virtual DbSet<Produto> Produtos { get; set; }

    //    public virtual DbSet<Usuario> Usuarios { get; set; }

    //    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    {
    //        if (!optionsBuilder.IsConfigured)
    //        {
    //            optionsBuilder.UseSqlServer
    //              ("Data Source=DESKTOP-66T8ILU\\sqlexpress;Initial Catalog=BD-Inventario;Integrated Security=True; TrustServerCertificate=true");
    //        }
    //    }

    //    //MANTER POIS NÃO SEI SE AINDA SERÁ NECESSÁRIO
    //    //=> optionsBuilder.UseSqlServer("" +
    //    //    "Data Source=DESKTOP-66T8ILU\\sqlexpress;Initial Catalog=BD-Inventario;Integrated Security=True; TrustServerCertificate=true");

    //    protected override void OnModelCreating(ModelBuilder modelBuilder)
    //    {
    //        modelBuilder.Entity<Produto>(entity =>
    //        {
    //            entity.HasKey(e => e.ProdutoId);
    //            entity.Property(e => e.Imagem).HasMaxLength(250);
    //            entity.Property(e => e.Nome)
    //                  .HasMaxLength(100)
    //                  .IsRequired();
    //            entity.Property(e => e.Preco).HasColumnType("decimal(18, 0");
    //        });

    //        modelBuilder.Entity<Usuario>(entity =>
    //        {
    //            entity.HasKey(e => e.UsuarioId);
    //            entity.Property(e => e.Email).HasMaxLength(250);
    //            entity.Property(e => e.Login).HasMaxLength(80).IsRequired();
    //            entity.Property(e => e.Nome).HasMaxLength(100).IsRequired();
    //            entity.Property(e => e.Senha).HasMaxLength(80).IsRequired();
    //        });

    //        OnModelCreatingPartial(modelBuilder);
    //    }
    //    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    //}
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }
        public virtual DbSet<Produto> Produtos { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer
                  ("Data Source=DESKTOP-66T8ILU\\SQLEXPRESS;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False; TrustServerCertificate=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.ProdutoId);
                entity.Property(e => e.Imagem).HasMaxLength(250);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Preco).HasColumnType("decimal(18, 0)");
            });
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.UsuarioId);
                entity.Property(e => e.Email).HasMaxLength(250);
                entity.Property(e => e.Login)
                    .IsRequired()
                    .HasMaxLength(80);
                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(100);
                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(80);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

