using Crud.ApplicationCore.Interfaces.Services;
using Crud.DTOS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.DTOS.Interfaces.Services.Ef
{
	public interface IVeiculoCondutorService: ICrudService
	{
		Veiculo GetHistorioVeiculoCondutores(string placa);
		Condutor GetHistorioCondutoresVeiculo(string CPF);
	}
}
