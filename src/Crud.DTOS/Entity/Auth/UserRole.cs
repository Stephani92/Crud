using Crud.DTOS.Entity;

namespace Crud.ApplicationCore.Entity
{
	public class UserRole
	{
		public UserRole()
		{
		}

		public UserRole(string user, string role)
		{
			UserEmail = user;
			RoleName = role;
		}
		public string UserEmail { get; set; }
		public string RoleName { get; set; }
		public Usuario User { get; set; }
		public Role Role { get; set; }
	}
}