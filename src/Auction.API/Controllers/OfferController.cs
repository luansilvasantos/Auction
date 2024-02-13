using AuctionProject.API.Communication.Requests;
using AuctionProject.API.Filters;
using AuctionProject.API.useCase.Offers.CreateOffer;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace AuctionProject.API.Controllers
{
    
    public class OfferController : AuctionBaseController
    {
        [HttpPost]
        [Route("{ItemId}")]
        [ServiceFilter(typeof(AuthenticationUserAttribute))]
        public IActionResult CreateOffer(
            [FromRoute] int ItemId, 
            [FromBody] RequestCreateOfferJson request,
            [FromServices] CreateOfferUseCase useCase
            ) 
        {
            var id = useCase.Execute(ItemId, request);
            return Created(string.Empty, id);
        }
    }
}
 
