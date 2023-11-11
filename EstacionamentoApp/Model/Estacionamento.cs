using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Model
{
    public class Estacionamento
    {
        public Vaga<Veiculo> VagasMoto { get; private set; }
        public Vaga<Veiculo> VagasVan { get; private set; }
        public VagaCarro VagasCarro { get; private set; }

        public Estacionamento(int vagasMoto, int vagasCarro, int vagasVan)
        {
            VagasMoto = new Vaga<Veiculo>(1, vagasMoto, vagasMoto);
            VagasCarro = new VagaCarro(vagasCarro);
            VagasVan = new Vaga<Veiculo>(3, vagasVan, vagasVan);
        }

        public int VagasTotaisDisponiveis()
        {
            return this.VagasMoto.VagasDisponiveis
                + this.VagasCarro.VagasDisponiveis
                + this.VagasVan.VagasDisponiveis;
        }

        public bool EstacionamentoCheio()
        {
            return this.VagasMoto.VagasDisponiveis == 0
                && this.VagasCarro.VagasDisponiveis == 0
                && this.VagasVan.VagasDisponiveis == 0;
        }

        public bool EstacionamentoVazio()
        {
            return this.VagasMoto.VagasDisponiveis == this.VagasMoto.QuantidadeVagas
                && this.VagasCarro.VagasDisponiveis == this.VagasCarro.QuantidadeVagas 
                && this.VagasVan.VagasDisponiveis == this.VagasVan.QuantidadeVagas;
        }

        public int TotalVagasEstacionamento()
        {
            return this.VagasMoto.QuantidadeVagas
                + this.VagasCarro.QuantidadeVagas
                + this.VagasVan.QuantidadeVagas;
        }
    }
}
