using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelDto.Users
{
	public class AuthModel
	{

		public int UserId { get; set; }
		public string Message { get; set; }
		public bool IsAuthenticated { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public string Token { get; set; }
		public DateTime ExpiresOn { get; set; }
		public List<string> Roles { get; set; }
	
	
		public AuthModel() { }

        public static implicit operator string(AuthModel v)
        {
            throw new NotImplementedException();
        }
    }
}
