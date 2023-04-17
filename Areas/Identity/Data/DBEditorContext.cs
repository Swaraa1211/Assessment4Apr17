using Assessment4Apr17.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assessment4Apr17.Areas.Identity.Data;

public class DBEditorContext : IdentityDbContext<EditorUser>
{
    public DBEditorContext(DbContextOptions<DBEditorContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        //base.OnModelCreating(builder);
        //builder.Property(x => x.Name).HasMaxLength(100);
    }
}
