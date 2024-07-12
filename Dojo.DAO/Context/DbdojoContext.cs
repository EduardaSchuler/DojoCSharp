using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Dojo.DAO.Context;

public partial class DbdojoContext : DbContext
{
    public DbdojoContext()
    {
    }

    public DbdojoContext(DbContextOptions<DbdojoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=DBDojo;Integrated Security=False;TrustServerCertificate=True;user=sa;password=!Floraefauna12");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("USUARIOS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Ativo)
                .HasDefaultValueSql("((1))")
                .HasColumnName("ATIVO");
            entity.Property(e => e.Cpf)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("CPF");
            entity.Property(e => e.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DATA_CADASTRO");
            entity.Property(e => e.DataNascimento)
                .HasColumnType("datetime")
                .HasColumnName("DATA_NASCIMENTO");
            entity.Property(e => e.Nome)
                .HasMaxLength(80)
                .IsUnicode(false)
                .HasColumnName("NOME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
