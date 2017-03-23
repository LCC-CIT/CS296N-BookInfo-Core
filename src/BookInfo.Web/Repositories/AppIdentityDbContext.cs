using BookInfo.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookInfo.Web.Repositories
{
    public class AppIdentityDbContext : IdentityDbContext<IdentityReader>
    {
            public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options)
            : base(options) { }
    }
}
