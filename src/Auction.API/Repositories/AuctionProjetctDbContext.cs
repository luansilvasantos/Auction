using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace AuctionProject.API.Repositories
{
    public class AuctionProjetctDbContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source = C:\\Users\\luanx\\Downloads\\leilaoDbNLW.db");
        }
    }
}
