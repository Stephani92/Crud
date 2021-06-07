using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.DTOS.Interfaces.Services.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Services.Ef
{
	public class CondutoresService : CrudService, ICondutoresService
	{
		public CondutoresService(IRepository efRepository) : base(efRepository)
		{
		}

	}
}
