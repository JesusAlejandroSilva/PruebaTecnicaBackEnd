using EntitiesLayer.DTOs;
using Microsoft.Ajax.Utilities;
using System.Web.Http;
using Test.API.Helpers;

namespace Test.API.Controllers
{
    [AllowAnonymous]
    public class AccountController : ApiController
    {
        /// <summary>
        /// AuthV1
        /// </summary>
        /// <param name="accountDTO"></param>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult Login(AccountDTO accountDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //TestQuemado
            bool isCredentialValid = accountDTO.Password == "12345";
            if (isCredentialValid)
            {
                var token = TokenGenerator.GenerateTokenJwt(accountDTO.Username);
                return Ok(token);
            }
            else
                return Unauthorized();
        }
    }
}
