using ProjetBanque.Abstractions.Services;
using System.IdentityModel.Tokens.Jwt;

namespace ProjetBanque.Services
{
	public class SecuriteService : ISecuriteService
	{
		public string UserId { get; set; }

		public bool EstAutorise(string token)
		{
			JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
			JwtSecurityToken jwtToken = handler.ReadJwtToken(token);
			var userId = jwtToken.Payload["UserId"].ToString();
			return userId is null ? false : userId.Equals(UserId);
		}
	}
}
