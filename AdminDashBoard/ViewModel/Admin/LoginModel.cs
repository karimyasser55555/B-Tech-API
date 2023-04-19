using System.ComponentModel.DataAnnotations;

namespace AdminDashBoard.ViewModel.Admin
{
    public class LoginModel
    {
        [Required,MinLength(3),MaxLength(200)]
        public string UserName { get; set; }
        [DataType(DataType.Password),MinLength(8)]
        public string Password { get; set; }
        public LoginModel() { }
        public LoginModel(string username, string password)
        {
            UserName = username;
            Password = password;
        }
    }
}
