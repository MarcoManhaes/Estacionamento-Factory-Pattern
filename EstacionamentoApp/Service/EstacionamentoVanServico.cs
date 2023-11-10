using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Service
{
    public class EstacionamentoVanServico : IServicoEstacionamento
    {
        private readonly Estacionamento _estacionamento;

        public EstacionamentoVanServico(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public void EstacionarVeiculoServico()
        {
            if (_estacionamento.VagasVan.VagasDisponiveis > 0 && _estacionamento.VagasVan.AceitaVeiculo(new Van()))
            {
                _estacionamento.VagasVan.VagasDisponiveis--;
                _estacionamento.VagasVan.VeiculosOcupantes.Add(new Van());
                Console.WriteLine("Um veículo do tipo Van foi estacionado na vaga de Van.\n");
            }
            else if (_estacionamento.VagasCarro.VagasDisponiveis > 2 && _estacionamento.VagasCarro.AceitaVeiculo(new Van()))
            {
                _estacionamento.VagasCarro.VagasDisponiveis -= (new Van()).Tamanho;
                _estacionamento.VagasCarro.VeiculosOcupantes.Add(new Van());
                Console.WriteLine("Um veículo do tipo Van foi estacionado na vaga de Carro.\n");
            }
            else
                Console.WriteLine("Não há vagas disponíveis para estacionar Vans.\n");

            if (_estacionamento.EstacionamentoCheio())
                Console.WriteLine("O estacionamento está cheio.\n");

            _estacionamento.ImprimirLogStatusEstacionamento();
        }

        public void RetirarVeiculoServico()
        {
            if (_estacionamento.VagasCarro.VeiculosOcupantes.Any(veiculo => veiculo is Van))
            {
                Veiculo vanToRemove = _estacionamento.VagasCarro.VeiculosOcupantes.First(veiculo => veiculo is Van);
                _estacionamento.VagasCarro.VeiculosOcupantes.Remove(vanToRemove);
                _estacionamento.VagasCarro.VagasDisponiveis += (new Van()).Tamanho; 
                Console.WriteLine("Um veículo do tipo Van foi retirado da vaga de Carro.\n");
            }
            else if (_estacionamento.VagasVan.VeiculosOcupantes.Any(veiculo => veiculo is Van))
            {
                Veiculo vanToRemove = _estacionamento.VagasVan.VeiculosOcupantes.First(veiculo => veiculo is Van);
                _estacionamento.VagasVan.VeiculosOcupantes.Remove(vanToRemove);
                _estacionamento.VagasVan.VagasDisponiveis++; 
                Console.WriteLine("Um veículo do tipo Van foi retirado da vaga de Van.\n");
            }
            else
            {
                Console.WriteLine("Não há veículos do tipo Van para retirar.\n");
            }

            _estacionamento.ImprimirLogStatusEstacionamento();
        }
    }
}
