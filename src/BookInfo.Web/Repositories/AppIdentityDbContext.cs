using BookInfo.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.Web.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<Reader>
    {
            public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
    }
}
