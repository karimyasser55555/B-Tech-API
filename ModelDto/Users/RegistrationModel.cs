using Domain;
using System.ComponentModel.DataAnnotations;


namespace ModelDto.Users
{
	public class RegistrationModel
	{
		[Required,MinLength(3),MaxLength(100)]
		public string FirstName { get; set; }
		[Required, MinLength(3), MaxLength(100)]
		public string LastName { get; set; }
		[Required, MinLength(3), MaxLength(100)]
		public string UserName { get; set; }
		[Required,DataType(DataType.EmailAddress), MinLength(3), MaxLength(100)]
		public string Email { get; set; }
		[Required,DataType(DataType.Password), MinLength(8), MaxLength(100)]
		public string Password { get; set; }
        [Required, DataType(DataType.Password), MinLength(8), MaxLength(100)]
        public string ConfirmedPassword { get; set; }

        public RegistrationModel() { }

        public RegistrationModel(string firstName, string lastName, string userName, string email, string password)
		{
		
			FirstName = firstName;
			LastName = lastName;
			UserName = userName;
			Email = email;
			Password = password;
			
		}
		}

	public static class RegistrationModelExtensions
	{
		public static User ToModel(this RegistrationModel registrationModel )
		{

			return new User()
			{
				Fname = registrationModel.FirstName,
				Lname = registrationModel.LastName,
				UserName = registrationModel.UserName,
				Email = registrationModel.Email

			};
				}
	}
}

