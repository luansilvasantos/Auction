using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Contracts;
using AuctionProject.API.Entities;
using AuctionProject.API.Services;
using AuctionProject.API.useCase.Offers.CreateOffer;
using Bogus;
using Moq;
using Xunit;

namespace UseCasesTest.Offers.CreateOffer
{
    public class CreateOfferUserCaseTest
    {
        [Fact]
        public void Success()
        {
            //Arrange
            var requestOffer = new Faker<RequestCreateOfferJson>()
                .RuleFor(request => request.Price, fakerOffer => fakerOffer.Random.Decimal(1, 700)).Generate();


            var offerRepository = new Mock<IOfferRepository>();
            var loggedUser = new Mock<ILoggedUser>();
            loggedUser.Setup(i => i.User()).Returns(new User());

            var useCase = new CreateOfferUseCase(loggedUser.Object, offerRepository.Object);

            //Act
            var auction = useCase.Execute(0, requestOffer);

            //Assert
            //auction.Should().NotBeNull();
        }
    }
}
