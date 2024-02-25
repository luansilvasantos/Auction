using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Enums;
using AuctionProject.API.useCase.Auctions.GetCurrent;
using Bogus;
using FluentAssertions;
using Moq;
using Xunit;

namespace UseCasesTest.Auctions
{
    public class GetCurrentAuctionUseCaseTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var entityAuction = new Faker<Auction>()
                .RuleFor(auction => auction.Id, fakerAuction => fakerAuction.Random.Number(1, 700))
                .RuleFor(auction => auction.Name, fakerAuction => fakerAuction.Lorem.Word())
                .RuleFor(auction => auction.Starts, fakerAuction => fakerAuction.Date.Past())
                .RuleFor(auction => auction.Ends, fakerAuction => fakerAuction.Date.Future())
                .RuleFor(auction => auction.Items, (fakerItem, auction) => new List<Item>
                {
                    new Item
                    {
                        Id = fakerItem.Random.Number(1, 700),
                        Name = fakerItem.Commerce.ProductName(),
                        Brand = fakerItem.Commerce.Department(),
                        BasePrice = fakerItem.Random.Decimal(50, 1000),
                        Condition = fakerItem.PickRandom<Condition>(),
                        AuctionId = auction.Id
                    }
                }).Generate();


            var mock = new Mock<IAuctionRepository>();
            mock.Setup(i => i.GetCurrent()).Returns(entityAuction);
            var useCase = new GetCurrentAuctionUseCase(mock.Object);

            //Act
            var auction = useCase.Execute();

            //Assert
            auction.Should().NotBeNull();
            auction.Id.Should().Be(entityAuction.Id);
            auction.Name.Should().Be(entityAuction.Name);
        }
    }
}
