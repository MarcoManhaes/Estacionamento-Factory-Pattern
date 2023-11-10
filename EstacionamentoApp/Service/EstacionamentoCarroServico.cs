using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Service
{
    public class EstacionamentoCarroServico : IServicoEstacionamento
    {
        private readonly Estacionamento _estacionamento;
        public EstacionamentoCarroServico(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public void EstacionarVeiculoServico()
        {
            if (_estacionamento.VagasCarro.VagasDisponiveis > 0 && _estacionamento.VagasCarro.AceitaVeiculo(new Carro()))
            {
                _estacionamento.VagasCarro.VagasDisponiveis--;
                _estacionamento.VagasCarro.VeiculosOcupantes.Add(new Carro());
                Console.WriteLine("Um veículo do tipo Carro foi estacionado na vaga de Carro.\n");
            }
            else if (_estacionamento.VagasVan.VagasDisponiveis > 0)
            {
                _estacionamento.VagasVan.VagasDisponiveis --;
                _estacionamento.VagasVan.VeiculosOcupantes.Add(new Carro());
                Console.WriteLine("Um veículo do tipo Carro foi estacionado na vaga de Van.\n");
            }
            else
                Console.WriteLine("Não há vagas disponíveis para estacionar Carros.\n");
                
            if(_estacionamento.EstacionamentoCheio())
                Console.WriteLine("O estacionamento está cheio.\n");

            _estacionamento.ImprimirLogStatusEstacionamento();
        }

        public void RetirarVeiculoServico()
        {
            if (_estacionamento.VagasVan.VeiculosOcupantes.Any(veiculo => veiculo is Carro))
            {
                Veiculo carroToRemove = _estacionamento.VagasVan.VeiculosOcupantes.First(veiculo => veiculo is Carro);
                _estacionamento.VagasVan.VeiculosOcupantes.Remove(carroToRemove);
                _estacionamento.VagasVan.VagasDisponiveis++;
                Console.WriteLine("Um veículo do tipo Carro foi retirado da vaga de Van.\n");
            }
            else if (_estacionamento.VagasCarro.VeiculosOcupantes.Any(veiculo => veiculo is Carro))
            {
                Veiculo carroToRemove = _estacionamento.VagasCarro.VeiculosOcupantes.First(veiculo => veiculo is Carro);
                _estacionamento.VagasCarro.VeiculosOcupantes.Remove(carroToRemove);
                _estacionamento.VagasCarro.VagasDisponiveis ++;
                Console.WriteLine("Um veículo do tipo Carro foi retirado da vaga de Carro.\n");
            }
            else
            {
                Console.WriteLine("Não há veículos do tipo Carro para retirar.\n");
            }

            _estacionamento.ImprimirLogStatusEstacionamento();
        }
    }
}
