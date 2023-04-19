using ModelDto.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
	public interface IUserRepository
	{
		Task<AuthModel> Registration(RegistrationModel registrationModel);
		Task<AuthModel> Login(LoginModel loginModel);
	}
}
