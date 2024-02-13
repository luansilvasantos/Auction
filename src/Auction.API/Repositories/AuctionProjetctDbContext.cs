using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.Repositories
{
    public class AuctionProjetctDbContext : DbContext
    {
        public AuctionProjetctDbContext(DbContextOptions options) : base(options) { }     
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Offer> Offers { get; set; }
    }
}
