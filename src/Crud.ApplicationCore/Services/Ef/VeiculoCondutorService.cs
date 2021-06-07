using Crud.ApplicationCore.Interfaces.Repositories;
using Crud.ApplicationCore.Interfaces.Services;
using Crud.DTOS.Entity;
using Crud.DTOS.Interfaces.Repositories;
using Crud.DTOS.Interfaces.Services.Ef;
using System;

namespace Crud.ApplicationCore.Services.Ef
{
	public class VeiculoCondutorService : CrudService, IVeiculoCondutorService
	{
		private readonly IVeiculoCondutorEfRepository _condutorEfRepository;

		public VeiculoCondutorService(IRepository efRepository, 
									  IVeiculoCondutorEfRepository condutorEfRepository) : base(efRepository)
		{
			_condutorEfRepository = condutorEfRepository;
		}

		public void AddVeiculoCondutores(VeiculoCondutores veiculosCondutoresDto)
		{
			var condutor = GetAsyncById<Condutor>(veiculosCondutoresDto.CondutorCpf);
			if (condutor is null) throw new ArgumentException("Condutor não cadastrado");
			var veiculo = GetAsyncById<Veiculo>(veiculosCondutoresDto.VeiculoPlaca);
			if (veiculo is null) throw new ArgumentException("Veiculo não cadastrado");

			Add(new VeiculoCondutores() 
				{ 
					DataCompra = veiculosCondutoresDto.DataCompra, 
					DataVenda = veiculosCondutoresDto.DataVenda, 
					Condutor = condutor, 
					Veiculo = veiculo 
				}
			);
		}

		public void UpdateVeiculoCondutores(VeiculoCondutores veiculosCondutoresDto)
		{
			var VeiculoCondutor = GetAsyncById<VeiculoCondutores>( veiculosCondutoresDto.VeiculoPlaca + veiculosCondutoresDto.CondutorCpf);
			if (VeiculoCondutor is null) throw new ArgumentException("Registro não cadastrado");
			VeiculoCondutor.DataVenda = veiculosCondutoresDto.DataVenda;
			Update(VeiculoCondutor);
		}
		public Condutor GetHistorioCondutoresVeiculo(string Cpf)
		{
			return _condutorEfRepository.GetHistorioCondutoresVeiculo(Cpf);
		}
		public Veiculo GetHistorioVeiculoCondutores(string placa)
		{
			return _condutorEfRepository.GetHistorioVeiculoCondutores(placa);
		}
	}
}
