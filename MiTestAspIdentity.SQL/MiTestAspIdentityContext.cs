using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MiTestAspIdentity.SQL.Model;


namespace MiTestAspIdentity.SQL
{
    public class MiTestAspIdentityContext: IdentityDbContext<Usuario>
    {
        public MiTestAspIdentityContext(DbContextOptions<MiTestAspIdentityContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
