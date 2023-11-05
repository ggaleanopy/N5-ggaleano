using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.Extensions.Configuration;

namespace DataAccessEF;

public partial class N5nowDbContext : DbContext
{
    protected readonly IConfiguration Configuration;

    //public N5nowDbContext()
    //{
    //}

    //public N5nowDbContext(DbContextOptions<N5nowDbContext> options)
    //    : base(options)
    //{
    //}

    public N5nowDbContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<PermissionType> PermissionTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Permission>(entity =>
        {
            entity.Property(e => e.Id).HasComment("Unique Id");
            entity.Property(e => e.ApellidoEmpleado)
                .HasComment("Employee Surname")
                .HasColumnType("text");
            entity.Property(e => e.FechaPermiso)
                .HasComment("Permission granted on date")
                .HasColumnType("date");
            entity.Property(e => e.NombreEmpleado)
                .HasComment("Employee Forename")
                .HasColumnType("text");
            entity.Property(e => e.TipoPermiso).HasComment("Permission type");

            //entity.HasOne(d => d.TipoPermisoNavigation).WithMany(p => p.Permissions)
            //    .HasForeignKey(d => d.TipoPermiso)
            //    .OnDelete(DeleteBehavior.ClientSetNull)
            //    .HasConstraintName("FK_Permissions_PermissionType");
        });

        modelBuilder.Entity<PermissionType>(entity =>
        {
            entity.ToTable("PermissionType");

            entity.Property(e => e.Id).HasComment("Unique Id");
            entity.Property(e => e.Descripcion)
                .HasComment("Permission description")
                .HasColumnType("text");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
