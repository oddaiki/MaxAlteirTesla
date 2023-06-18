using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTesla
{
	internal class Program
	{
		//A empresa MaxAlteirTesla possui um numero de 40.000 funcionarios
		//Hoje em dia a empresa sofre com problemas de controle de funcionarios
		//O setor de RH nao consegue ter o controle do estado dos seus funcionarios
		//Exemplo: Quantidade de especializações, quantidade de funcionarios por setor,
		//média de salario de cada setor
		//Registro de tempo por setor
		//Cadastro de funcionarios por setor
		//Listagem de funcionarios por setor.

		static void Main(string[] args)
		{
			Rh rh = new Rh();

			// Adicionar funcionários
			for (int i = 1; i <= 5; i++)
			{
				Console.WriteLine($"Adicionar Funcionário {i}:");
				Funcionario funcionario = CriarFuncionario();
				rh.AdicionarFuncionario(funcionario);
				Console.WriteLine();
			}

			// Obter quantidade de funcionários
			int quantidadeFuncionarios = rh.ObterQuantidadeFuncionarios();
			Console.WriteLine("Quantidade de funcionários: " + quantidadeFuncionarios);

			// Obter quantidade de especializações
			int quantidadeEspecializacoes = rh.ObterQuantidadeEspecializacoes();
			Console.WriteLine("Quantidade de especializações: " + quantidadeEspecializacoes);

			// Obter quantidade de funcionários por setor
			Console.Write("Digite o setor para obter a quantidade de funcionários: ");
			string setor = Console.ReadLine();
			int quantidadeFuncionariosSetor = rh.ObterQuantidadeFuncionariosPorSetor(setor);
			Console.WriteLine("Quantidade de funcionários no setor " + setor + ": " + quantidadeFuncionariosSetor);

			// Calcular média salarial por setor
			decimal mediaSalarioSetor = rh.CalcularMediaSalarioPorSetor(setor);
			Console.WriteLine("Média salarial do setor " + setor + ": " + mediaSalarioSetor);

			// Calcular tempo de trabalho por setor
			TimeSpan tempoTrabalhoSetor = rh.CalcularTempoTrabalhoPorSetor(setor);
			Console.WriteLine("Tempo de trabalho no setor " + setor + ": " + tempoTrabalhoSetor.TotalDays + " dias");

			// Obter funcionários por setor
			Console.WriteLine("Funcionários do setor " + setor + ":");
			List<Funcionario> funcionariosSetor = rh.ObterFuncionariosPorSetor(setor);
			foreach (var funcionario in funcionariosSetor)
			{
				Console.WriteLine(funcionario.Nome);
			}

			Console.ReadLine();
		}

		static Funcionario CriarFuncionario()
		{
			Funcionario funcionario = new Funcionario();

			Console.Write("Digite o nome do funcionário: ");
			funcionario.Nome = Console.ReadLine();

			Console.Write("Digite o setor do funcionário: ");
			funcionario.Setor = Console.ReadLine();

			Console.WriteLine("Digite as especializações do funcionário (digite 'fim' para parar):");
			funcionario.Especializacoes = new List<string>();
			string especializacao;
			do
			{
				especializacao = Console.ReadLine();
				if (especializacao.ToLower() != "fim")
				{
					funcionario.Especializacoes.Add(especializacao);
				}
			} while (especializacao.ToLower() != "fim");

			Console.Write("Digite o salário do funcionário: ");
			funcionario.Salario = decimal.Parse(Console.ReadLine());

			Console.Write("Digite a data de admissão do funcionário (formato dd/mm/yyyy): ");
			funcionario.DataAdmissao = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", null);

			return funcionario;
		}
	}
}
