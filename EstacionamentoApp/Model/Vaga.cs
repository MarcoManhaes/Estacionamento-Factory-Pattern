using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Model
{
    public class Vaga<T> where T : Veiculo
    {
        public static int TamanhoVaga { get; set; }
        public int QuantidadeVagas { get; set; }
        public int VagasDisponiveis { get; set; }
        public List<Veiculo> VeiculosOcupantes { get; set; } = new List<Veiculo>();

        public Vaga(int tamanho, int quantidadeVagas, int vagasDisponiveis)
        {
            TamanhoVaga = tamanho;
            QuantidadeVagas = quantidadeVagas;
            VagasDisponiveis = vagasDisponiveis;
        }

        public virtual bool AceitaVeiculo(T veiculo)
        {
            return veiculo.Tamanho <= TamanhoVaga;
        }
    }
}
