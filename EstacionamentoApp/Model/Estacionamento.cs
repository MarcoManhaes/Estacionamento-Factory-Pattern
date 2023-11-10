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

        public void ImprimirLogStatusEstacionamento()
        {
            Console.WriteLine("\nStatus atual do estacionamento:");
            Console.WriteLine($"Vaga(s) de motos: {this.VagasMoto.VagasDisponiveis} de {this.VagasMoto.QuantidadeVagas}");
            Console.WriteLine($"Vaga(s) de carros: {this.VagasCarro.VagasDisponiveis} de {this.VagasCarro.QuantidadeVagas}");
            Console.WriteLine($"Vaga(s) de vans: {this.VagasVan.VagasDisponiveis} de {this.VagasVan.QuantidadeVagas}\n");
            
            if(this.EstacionamentoVazio())
                Console.WriteLine($"*** O estacionamento está vazio");

            if (this.EstacionamentoCheio())
                Console.WriteLine($"*** O estacionamento está cheio");

            Console.WriteLine("------------------------------------------");
        }

        public void ImprimirLogVagasRestantesEstacionamento()
        {
            Console.WriteLine($"Restam: {this.VagasTotaisDisponiveis()} vaga(s), sendo:");
            Console.WriteLine($"{this.VagasMoto.VagasDisponiveis} vaga(s) esclusiva(s) de Moto, " +
                              $"{this.VagasCarro.VagasDisponiveis} vaga(s) esclusiva(s) de Carro e " +
                              $"{this.VagasVan.VagasDisponiveis} vaga(s) exclusiva(s) de Van");

            Console.WriteLine("------------------------------------------\n");
        }

        public void ImprimirLogQuantidadeVagasEstacionamentoPossui()
        {
            Console.WriteLine($"\nO estacionamento possui um total de {this.TotalVagasEstacionamento()} vaga(s) (considerando ocupadas e vazias), sendo:");
            Console.WriteLine($"{this.VagasMoto.QuantidadeVagas} vaga(s) esclusiva(s) de Moto, " +
                              $"{this.VagasCarro.QuantidadeVagas} vaga(s) esclusiva(s) de Carro e " +
                              $"{this.VagasVan.QuantidadeVagas} vaga(s) exclusiva(s) de Van");

            Console.WriteLine("------------------------------------------\n");
        }
    }
}
