using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Model;
using EstacionamentoApp.Util;
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
                Console.WriteLine(Resource.msgCarroEstacionadoVagaCarro);
            }
            else if (_estacionamento.VagasVan.VagasDisponiveis > 0)
            {
                _estacionamento.VagasVan.VagasDisponiveis --;
                _estacionamento.VagasVan.VeiculosOcupantes.Add(new Carro());
                Console.WriteLine(Resource.msgCarroEstacionadoVagaVan);
            }
            else
                Console.WriteLine(Resource.msgNaoHaVagasCarro);
                
            if(_estacionamento.EstacionamentoCheio())
                Console.WriteLine(Resource.msgEstacinamentoCheio);

            LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
        }

        public void RetirarVeiculoServico()
        {
            if (_estacionamento.VagasVan.VeiculosOcupantes.Any(veiculo => veiculo is Carro))
            {
                Veiculo carroToRemove = _estacionamento.VagasVan.VeiculosOcupantes.First(veiculo => veiculo is Carro);
                _estacionamento.VagasVan.VeiculosOcupantes.Remove(carroToRemove);
                _estacionamento.VagasVan.VagasDisponiveis++;
                Console.WriteLine(Resource.msgCarroRetiradoVagaVan);
            }
            else if (_estacionamento.VagasCarro.VeiculosOcupantes.Any(veiculo => veiculo is Carro))
            {
                Veiculo carroToRemove = _estacionamento.VagasCarro.VeiculosOcupantes.First(veiculo => veiculo is Carro);
                _estacionamento.VagasCarro.VeiculosOcupantes.Remove(carroToRemove);
                _estacionamento.VagasCarro.VagasDisponiveis ++;
                Console.WriteLine(Resource.msgCarroRetiradoVagaCarro);
            }
            else
            {
                Console.WriteLine(Resource.msgNaoHaCarroParaRetirar);
            }

            LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
        }
    }
}
