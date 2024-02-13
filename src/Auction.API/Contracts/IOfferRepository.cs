using AuctionProject.API.Entities;
using AuctionProject.API.Repositories;

namespace AuctionProject.API.Contracts
{
    public interface IOfferRepository
    {
        void Add(Offer offer) ;
    }
}
