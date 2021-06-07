
using Crud.ApplicationCore.Entity;
using Crud.DTOS.Entity;

namespace Crud.ApplicationCore.Interfaces.Repositories
{

	public interface IUsuarioEfRepository : IRepository
	{
		Usuario GetUsuarioAsyncByEmail(string UserEmail);
	}
}
