using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Model
{
    public class VagaCarro : Vaga<Veiculo>
    {
        public VagaCarro(int vagasDisponiveis) : base(2, vagasDisponiveis, vagasDisponiveis) { }

        public override bool AceitaVeiculo(Veiculo veiculo)
        {
            return veiculo.Tamanho <= TamanhoVaga || veiculo is Van;
        }
    }
}
