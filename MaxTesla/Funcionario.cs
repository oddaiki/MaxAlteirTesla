using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaxTesla
{
	public class Funcionario
	{
		public string Nome { get; set; }
		public string Setor { get; set; }
		public List<string> Especializacoes { get; set; }
		public decimal Salario { get; set; }
		public DateTime DataAdmissao { get; set; }
	}
}
