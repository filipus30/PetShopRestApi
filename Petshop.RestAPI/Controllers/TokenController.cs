using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Petshop.Core.DomainService;
using Petshop.Core.Entity;
using Petshop.RestAPI.Helper;

namespace Petshop.RestAPI.Controllers
{
    [Route("/api/token")]
    public class TokenController : Controller
    {
        private IUserRepository repository;
        private IAuthenticationHelper authenticationHelper;

        public TokenController(IUserRepository repos, IAuthenticationHelper authHelper)
        {
            repository = repos;
            authenticationHelper = authHelper;
        }


        [HttpPost]
        public IActionResult Login([FromBody] LoginInputModel model)
        {
            var user = repository.GetAll().FirstOrDefault(u => u.Username == model.Username);

            // check if username exists
            if (user == null)
                return Unauthorized();

            // check if password is correct
            if (!authenticationHelper.VerifyPasswordHash(model.Password, user.PasswordHash, user.PasswordSalt))
                return Unauthorized();

            // Authentication successful
            return Ok(new
            {
                username = user.Username,
                token = authenticationHelper.GenerateToken(user)
            });
        }

    }
}
