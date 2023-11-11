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
                Console.WriteLine(Resource.msgVanEstacionadaVagaVan);
            }
            else if (_estacionamento.VagasCarro.VagasDisponiveis > 2 && _estacionamento.VagasCarro.AceitaVeiculo(new Van()))
            {
                _estacionamento.VagasCarro.VagasDisponiveis -= (new Van()).Tamanho;
                _estacionamento.VagasCarro.VeiculosOcupantes.Add(new Van());
                Console.WriteLine(Resource.msgVanEstacionadaVagaCarro);
            }
            else
                Console.WriteLine(Resource.msgNaoHaVagasVan);

            if (_estacionamento.EstacionamentoCheio())
                Console.WriteLine(Resource.msgEstacinamentoCheio);

            LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
        }

        public void RetirarVeiculoServico()
        {
            if (_estacionamento.VagasCarro.VeiculosOcupantes.Any(veiculo => veiculo is Van))
            {
                Veiculo vanToRemove = _estacionamento.VagasCarro.VeiculosOcupantes.First(veiculo => veiculo is Van);
                _estacionamento.VagasCarro.VeiculosOcupantes.Remove(vanToRemove);
                _estacionamento.VagasCarro.VagasDisponiveis += (new Van()).Tamanho; 
                Console.WriteLine(Resource.msgVanRetiradaVagaCarro);
            }
            else if (_estacionamento.VagasVan.VeiculosOcupantes.Any(veiculo => veiculo is Van))
            {
                Veiculo vanToRemove = _estacionamento.VagasVan.VeiculosOcupantes.First(veiculo => veiculo is Van);
                _estacionamento.VagasVan.VeiculosOcupantes.Remove(vanToRemove);
                _estacionamento.VagasVan.VagasDisponiveis++; 
                Console.WriteLine(Resource.msgVanRetiradaVagaVan);
            }
            else
            {
                Console.WriteLine(Resource.msgNaoHaVanParaRetirar);
            }

            LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
        }
    }
}
