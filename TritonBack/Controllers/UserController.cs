using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TritonBack.Model;
using TritonBack.Service.Interface;

namespace TritonBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser user;

        public UserController(IUser user)
        {
            this.user = user;
        }

        [HttpPost("/register")]

        public async Task<ActionResult<UserModel>> Register(UserModelDto model)
        {
            var response = await user.Register(model);

           return Ok(response);
        }

        [HttpPost("/login")]

        public async Task<ActionResult<TokenModel>> Login (UserModelDto model)
        {
            var response = await user.Authentication(model);

            return Ok(response);
        }
    }
}
