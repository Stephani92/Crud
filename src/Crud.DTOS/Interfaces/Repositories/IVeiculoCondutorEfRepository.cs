using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.DTOS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DTOS.Interfaces.Repositories
{
	public interface IVeiculoCondutorEfRepository : IRepository
	{
		Veiculo GetHistorioVeiculoCondutores(string placa);
		Condutor GetHistorioCondutoresVeiculo(string CPF);
	}
}
