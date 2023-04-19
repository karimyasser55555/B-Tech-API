
using Domain;

namespace ModelDto.Users
{
	public class SignUpModel
	{
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public string Email { get; set; }
			public string Password { get; set; }
		}

		public static class SignUpModelExtensions
		{
			public static User ToModel(this SignUpModel signUpModel)
			{
				return new User
				{
					Fname = signUpModel.FirstName,
					Lname= signUpModel.LastName,
					UserName = signUpModel.Email,
					Email = signUpModel.Email
				};
			}
		}
	}