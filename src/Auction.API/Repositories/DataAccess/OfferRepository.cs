using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;

namespace AuctionProject.API.Repositories.DataAccess
{
    public class OfferRepository : IOfferRepository
    {
        private readonly AuctionProjetctDbContext _dbContext;
        public OfferRepository(AuctionProjetctDbContext dbContext) => _dbContext = dbContext;
        public void Add(Offer offer)
        {
            _dbContext.Offers.Add(offer);
            _dbContext.SaveChanges();
        }
    }
}
