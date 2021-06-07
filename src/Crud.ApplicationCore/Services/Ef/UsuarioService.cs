

using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;

namespace Crud.ApplicationCore.Services.Ef
{
	public class UsuarioService : CrudService, IUsuarioService
	{
		public UsuarioService(IRepository efRepository) : base(efRepository)
		{
		}
	}
}
