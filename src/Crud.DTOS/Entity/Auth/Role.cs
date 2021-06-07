using System.Collections.Generic;

namespace Crud.ApplicationCore.Entity
{
	public class Role
	{
		public Role()
		{
		}

		public Role(string name)
		{
			Name = name;
		}

		
		public string Name { get; set; }
		public List<UserRole> Usuarios { get; set; }
	}
}