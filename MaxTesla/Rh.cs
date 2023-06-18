using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTesla
{
	internal class Rh
	{
		private List<Funcionario> funcionarios;

		public Rh()
		{
			funcionarios = new List<Funcionario>();
		}

		public void AdicionarFuncionario(Funcionario funcionario)
		{
			funcionarios.Add(funcionario);
		}

		public int ObterQuantidadeFuncionarios()
		{
			return funcionarios.Count;
		}

		public int ObterQuantidadeEspecializacoes()
		{
			return funcionarios.Sum(f => f.Especializacoes.Count);
		}

		public int ObterQuantidadeFuncionariosPorSetor(string setor)
		{
			return funcionarios.Count(f => f.Setor == setor);
		}

		public decimal CalcularMediaSalarioPorSetor(string setor)
		{
			var funcionariosSetor = funcionarios.Where(f => f.Setor == setor);
			if (funcionariosSetor.Any())
			{
				return funcionariosSetor.Average(f => f.Salario);
			}
			else
			{
				return 0;
			}
		}

		public TimeSpan CalcularTempoTrabalhoPorSetor(string setor)
		{
			var funcionariosSetor = funcionarios.Where(f => f.Setor == setor);
			if (funcionariosSetor.Any())
			{
				DateTime dataAtual = DateTime.Now;
				var tempoTrabalho = dataAtual - funcionariosSetor.Min(f => f.DataAdmissao);
				return tempoTrabalho;
			}
			else
			{
				return TimeSpan.Zero;
			}
		}

		public List<Funcionario> ObterFuncionariosPorSetor(string setor)
		{
			return funcionarios.Where(f => f.Setor == setor).ToList();
		}
	}
}