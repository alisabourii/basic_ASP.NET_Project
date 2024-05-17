using Auctions.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auctions.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Listing> Listing { get; set; }
        public DbSet<Bid> Bid { get; set; }
        public DbSet<Comment> Comment { get; set; }
    }
}
