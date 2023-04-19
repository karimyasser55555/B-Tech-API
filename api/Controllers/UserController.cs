using ApiContext;
using Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using ModelDto.Users;

namespace api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserRepository _userRepository;
        private readonly DBContext _dBContext;

        public UserController(IUserRepository userRepository,DBContext dBContext) 
		{
			_userRepository = userRepository;
			_dBContext= dBContext;
		}

		// GET: Category
		[HttpGet(template: "GetAllUser")]
        public async Task<IActionResult> Index()
        {
            var data = _dBContext.Users.ToList();
			return Ok(data);
        }

        [HttpPost("Register")]
		public async Task<IActionResult> SignUp([FromForm] RegistrationModel registrationModel)
		{
            AuthModel resulat = await _userRepository.Registration(registrationModel);

			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			if (resulat.Message=="Email Is Already Registered!")
				return BadRequest(resulat);
            else if (resulat.Message == "Reigster Model is null!")
                return BadRequest(resulat);
            else if(resulat.Message == "UserName Is Already Registered!")
				return BadRequest(resulat);
			return Ok(resulat);

		}
		[HttpPost("login")]
		public async Task<IActionResult> LogIN([FromForm] LoginModel loginModel)
		{
			if (!ModelState.IsValid)
				return BadRequest(ModelState);
			AuthModel resulat = await _userRepository.Login(loginModel);
			if (resulat.Message=="Email or Password is incorrect!")
				return BadRequest(resulat);
			
			return Ok(resulat);

		}
        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] LoginModel loginModel,string Email)
        {

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            string resulat = await _userRepository.Login(loginModel);
            if (resulat.Equals("Email or Password is incorrect!"))
                return BadRequest(resulat);

            return Ok(resulat);

        }
    }
}
