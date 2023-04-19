using Application.Contracts;
using Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelDto.Users;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using InfraStructure.Helpers;
using Microsoft.Extensions.Options;

namespace Infrastructure
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<User> UserManager;
		private readonly IConfiguration _Configuration;
		private readonly  Jwt _jwt;
		private readonly RoleManager<Role> _roleManager; 

		public UserRepository(UserManager<User> userManager,IConfiguration configuration, IOptions<Jwt> jwt, RoleManager<Role> roleManager) 
		{
            UserManager = userManager;
            _Configuration = configuration;
            _roleManager = roleManager;
            _jwt = jwt.Value;
        }

		public async Task<AuthModel> Registration(RegistrationModel registrationModel)
		{
			if (registrationModel == null)
			{
				AuthModel authModel = new AuthModel();

				authModel.Message = "Model is empty";
				authModel.IsAuthenticated = false;
				return authModel;
			}
			if (registrationModel.Password != registrationModel.ConfirmedPassword)
			{
				AuthModel authModel = new AuthModel();
			
				authModel.Message ="Password and confirmedpassword are not match";
				authModel.IsAuthenticated = false;
				return authModel;

            }
        
			if (await UserManager.FindByEmailAsync(registrationModel.Email) != null)
			{ 
                AuthModel authModel = new AuthModel();

               authModel.Message = "Email Is Already Registered!";
               authModel.IsAuthenticated = false;
               return authModel;
            }


            
			if (await UserManager.FindByNameAsync(registrationModel.UserName)!= null)

			{
                AuthModel authModel = new AuthModel();

                authModel.Message = "UserName Is Already Registered!";
                authModel.IsAuthenticated = false;
                return authModel;



            }
	
			User _user = registrationModel.ToModel();
			var result = await UserManager.CreateAsync(_user,registrationModel.Password);
            if (!result.Succeeded)
            {
                var errors = string.Empty;
                foreach (var error in result.Errors)
                {
                    errors += $"{error.Description},";
                }
                
                return new AuthModel { Message = errors.ToString() }; ;
            }

            await UserManager.AddToRoleAsync(_user, "User");
			var SigninKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

			var UserClaims = new List<Claim>()
			{
				new Claim(ClaimTypes.Name,registrationModel.Email),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};

			var Token = new JwtSecurityToken
				(
					issuer: _jwt.ValidIssuer, //Configuration["JWT:ValidIssuer"],
					audience: _jwt.ValidAudience, //Configuration["JWT:ValidAudience"],
					expires: DateTime.Now.AddDays(_jwt.DurtionInDays),
					signingCredentials: new SigningCredentials(SigninKey, SecurityAlgorithms.HmacSha256Signature),
					claims: UserClaims
				); ;

			var jwtSecurityToken = await CreateJwtToken(_user);
			return new AuthModel
			{
				UserId = _user.Id,
				Email = _user.Email!,
				ExpiresOn = jwtSecurityToken.ValidTo,
				IsAuthenticated = true,
				Roles = new List<string> { "_user" },
				Username = _user.UserName!,
				Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)
			};
		}

		public async Task<AuthModel> Login(LoginModel loginModel)
		{
			AuthModel authModel=new AuthModel();
			var _user = await UserManager.FindByEmailAsync(loginModel.Email);
			var checkpass = await UserManager.CheckPasswordAsync(_user, loginModel.Password);

            if (_user is null )
			{
                AuthModel authModel1 = new AuthModel();

                authModel1.Message = "There is user with this Email!";
                authModel1.IsAuthenticated = false;
                return authModel1;

			}
			if(!checkpass)
			{
                AuthModel authModel1 = new AuthModel();

                authModel1.Message = "Invalid Password!";
                authModel1.IsAuthenticated = false;
                return authModel1;

            }
            var claims = new[]
           {
                new Claim("Email", loginModel.Email),
                new Claim(ClaimTypes.NameIdentifier, _user.UserName),
            };

                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Key"]));
                var token = new JwtSecurityToken(
                issuer: _Configuration["JWT:ValidIssuer"],
                audience: _Configuration["JWT:ValidAudience"],
                claims: claims,
                expires: DateTime.Now.AddDays(30),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));
                string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);


			    var jwtSecurityToken = await CreateJwtToken(_user);
			    var rollist = await UserManager.GetRolesAsync(_user);
			    authModel.IsAuthenticated = true;
		    	authModel.UserId = _user.Id;
			    authModel.Email = _user.Email!;
		    	authModel.Username = _user.UserName!;
			    authModel.ExpiresOn = jwtSecurityToken.ValidTo;
			    authModel.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
			    authModel.Roles = rollist.ToList();
			    return authModel;

		
        }
		private async Task<JwtSecurityToken> CreateJwtToken(User user)
		{
			var userClaims = await UserManager.GetClaimsAsync(user);
			var roles = await UserManager.GetRolesAsync(user);
			var roleClaims = new List<Claim>();

			foreach (var role in roles)
				roleClaims.Add(new Claim("roles", role));

			var claims = new[]
			{
				new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
				new Claim(JwtRegisteredClaimNames.Email, user.Email),
				
			}
			.Union(userClaims)
			.Union(roleClaims);

			var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));
			var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

			var jwtSecurityToken = new JwtSecurityToken(
				issuer: _jwt.ValidIssuer,
				audience: _jwt.ValidAudience,
				claims: claims,
				expires: DateTime.Now.AddDays(_jwt.DurtionInDays),
				signingCredentials: signingCredentials);


			return jwtSecurityToken;
		}

		public async Task<string> UpdateUser(LoginModel loginModel)
		{
			var _user = await UserManager.FindByEmailAsync(loginModel.Email);
            if (_user is null )
            {
                return "Email or Password is incorrect!";
            }
			else
			{
				return "HELLO";
			}

        }


    }
}
