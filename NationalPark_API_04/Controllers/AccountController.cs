using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NationalPark_API_04.IRepository;
using NationalPark_API_04.Model;

namespace NationalPark_API_04.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public AccountController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody]User user)
        {
            if(ModelState.IsValid)
            {
                var isUserUnique = _userRepository.IsUniqueUser(user.UserName);
                if(!isUserUnique)return BadRequest("User in DB, Jldi Vha se hto");
                var userInfo = _userRepository.Register(user.UserName, user.Password);
                if (userInfo == null) return BadRequest("error");
            }
            return Ok();
        }
        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] UserVM userVM)
        {
            var user= _userRepository.Authenticate(userVM.UserName,userVM.Password);
            if (user == null) return BadRequest("Wrong User/Password");
            return Ok(user);
        }
    }
}
