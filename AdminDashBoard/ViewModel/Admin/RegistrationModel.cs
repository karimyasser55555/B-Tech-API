using Domain;
using System.ComponentModel.DataAnnotations;

namespace AdminDashBoard.ViewModel.Admin
{
    public class RegistrationModel
    {

        [Required, MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }
        [Required, MinLength(3), MaxLength(100)]
        public string UserName { get; set; }
        [DataType(DataType.EmailAddress), RegularExpression(@"^[^@\s]+@[^@\s]+\.(com|net|org|gov)$")]
        public string Email { get; set; }
        [Required, DataType(DataType.Password),RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[#$^+=!*()@%&]).{8,}$")]
        public string Password { get; set; }
        public RegistrationModel()
        {

        }
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
        public static User ToModel(this RegistrationModel registrationModel)
        {
            return new User
            {
                Fname = registrationModel.FirstName,
                Lname = registrationModel.LastName,
                UserName = registrationModel.UserName,
                Email = registrationModel.Email
            };
        }
    }
}

