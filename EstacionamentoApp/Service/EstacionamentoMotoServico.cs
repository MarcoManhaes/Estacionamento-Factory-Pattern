using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Service
{
    public class EstacionamentoMotoServico : IServicoEstacionamento
    {
        private readonly Estacionamento _estacionamento;

        public EstacionamentoMotoServico(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public void EstacionarVeiculoServico()
        {
            if (_estacionamento.VagasMoto.VagasDisponiveis > 0 && _estacionamento.VagasMoto.AceitaVeiculo(new Moto()))
            {
                _estacionamento.VagasMoto.VagasDisponiveis--;
                _estacionamento.VagasMoto.VeiculosOcupantes.Add(new Moto());
                Console.WriteLine("Um veículo do tipo Moto foi estacionado na vaga de Moto.\n");
            }
            else if (_estacionamento.VagasCarro.VagasDisponiveis > 0)
            {
                _estacionamento.VagasCarro.VagasDisponiveis--;
                _estacionamento.VagasCarro.VeiculosOcupantes.Add(new Moto());
                Console.WriteLine("Um veículo do tipo Moto foi estacionado na vaga de Carro.\n");
            }
            else if (_estacionamento.VagasVan.VagasDisponiveis > 0)
            {
                _estacionamento.VagasVan.VagasDisponiveis--;
                _estacionamento.VagasVan.VeiculosOcupantes.Add(new Moto());
                Console.WriteLine("Um veículo do tipo Moto foi estacionado na vaga de Van.\n");
            }
            else
                Console.WriteLine("Não há vagas disponíveis para estacionar Motos.\n");

            if (_estacionamento.EstacionamentoCheio())
                Console.WriteLine("O estacionamento está cheio\n");

            _estacionamento.ImprimirLogStatusEstacionamento();
        }

        public void RetirarVeiculoServico()
        {
            if(_estacionamento.VagasVan.VeiculosOcupantes.Any(veiculo => veiculo is Moto))
            {
                Veiculo motoToRemove = _estacionamento.VagasVan.VeiculosOcupantes.First(veiculo => veiculo is Moto);
                _estacionamento.VagasVan.VeiculosOcupantes.Remove(motoToRemove);
                _estacionamento.VagasVan.VagasDisponiveis++;
                Console.WriteLine("Um veículo do tipo Moto foi retirado da vaga de Van.\n");
            }
            else if (_estacionamento.VagasCarro.VeiculosOcupantes.Any(veiculo => veiculo is Moto))
            {
                Veiculo motoToRemove = _estacionamento.VagasCarro.VeiculosOcupantes.First(veiculo => veiculo is Moto);
                _estacionamento.VagasCarro.VeiculosOcupantes.Remove(motoToRemove);
                _estacionamento.VagasCarro.VagasDisponiveis++;
                Console.WriteLine("Um veículo do tipo Moto foi retirado da vaga de Carro.\n");
            }
            else if (_estacionamento.VagasMoto.VeiculosOcupantes.Any(veiculo => veiculo is Moto))
            {
                Veiculo motoToRemove = _estacionamento.VagasMoto.VeiculosOcupantes.First(veiculo => veiculo is Moto);
                _estacionamento.VagasMoto.VeiculosOcupantes.Remove(motoToRemove);
                _estacionamento.VagasMoto.VagasDisponiveis++;
                Console.WriteLine("Um veículo do tipo Moto foi retirado da vaga de Moto.\n");
            }
            else
            {
                Console.WriteLine("Não há veículos do tipo Moto para retirar.\n");
            }

            _estacionamento.ImprimirLogStatusEstacionamento();
        }
    }
}
