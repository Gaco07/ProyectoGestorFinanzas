using GestorPersonal.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using GestorPersonal.Models;
using System.Collections;

namespace GestorPersonal.Areas.Identity.Data;

public class GGContext : IdentityDbContext<Usuario>
{
    public GGContext(DbContextOptions<GGContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);
    }

    public DbSet<GestorPersonal.Models.Categoria>? Categoria { get; set; }

    public DbSet<GestorPersonal.Models.Gasto>? Gasto { get; set; }

    public DbSet<GestorPersonal.Models.Informe>? Informe { get; set; }

    public DbSet<GestorPersonal.Models.Ingreso>? Ingreso { get; set; }
    public IEnumerable Usuario { get; internal set; }
}

//public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<Usuario>
//{
//    public void Configure(EntityTypeBuilder<Usuario> builder)
//    {
//        builder.Property(x => x.Nombre).HasMaxLength(50);
//    }
//}
