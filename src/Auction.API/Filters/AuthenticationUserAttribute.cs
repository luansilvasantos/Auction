using AuctionProject.API.Contracts;
using AuctionProject.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AuctionProject.API.Filters
{
    public class AuthenticationUserAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private IUserRepository _userRepository;

        public AuthenticationUserAttribute(IUserRepository userRepository) => _userRepository = userRepository;
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            try
            {
                var authenticationToken = TokenOnRequest(context.HttpContext);
                var email = DecodeFromBase64String(authenticationToken);
                var exist = _userRepository.ExistUserWithEmail(email);
                if (exist == false) context.Result = new UnauthorizedObjectResult("E-mail not valid");
                
            }
            catch (Exception ex) 
            {
                context.Result = new UnauthorizedObjectResult(ex.Message);
            }

          
        }

        private string TokenOnRequest(HttpContext context)
        {
            var authentication = context.Request.Headers.Authorization.ToString();
            if (string.IsNullOrEmpty(authentication))
            {
                throw new Exception("Token is missing.");
            }
            return authentication["Bearer ".Length..];
        }

        private string DecodeFromBase64String(string base64)
        {
            var data = Convert.FromBase64String(base64);
            return System.Text.Encoding.UTF8.GetString(data);
        }
    }
}
