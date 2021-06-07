using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.DTOS.Interfaces.Services.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.ApplicationCore.Services.Ef
{
	public class VeiculoService : CrudService, IVeiculoService
	{
		public VeiculoService(IRepository efRepository) : base(efRepository)
		{
		}
	}
}
