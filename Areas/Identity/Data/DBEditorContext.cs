using Assessment4Apr17.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Assessment4Apr17.Areas.Identity.Data;

public class DBEditorContext : IdentityDbContext<EditorUser>
{
    public DBEditorContext(DbContextOptions<DBEditorContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //builder.Property(x => x.Name).HasMaxLength(100);
    }
}
public class ApplicationUserEntityConfiguration : IEntityTypeConfiguration<EditorUser>
{
    public void Configure(EntityTypeBuilder<EditorUser> builder)
    {
        builder.Property(x => x.Name).HasMaxLength(100);
        //throw new NotImplementedException();
    }
}