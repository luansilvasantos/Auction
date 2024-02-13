using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace AuctionProject.API.Repositories.DataAccess
{
    public class AuctionRepository : IAuctionRepository
    {
        private readonly AuctionProjetctDbContext _dbContext;
        public AuctionRepository(AuctionProjetctDbContext dbContext) => _dbContext = dbContext;

        public Auction? GetCurrent()
        {
            return _dbContext
              .Auctions
              .Include(auction => auction.Items)
              .FirstOrDefault();
        }
    }
}
