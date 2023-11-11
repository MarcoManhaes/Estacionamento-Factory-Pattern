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
                Console.WriteLine(Resource.msgMotoEstacionadaVagaMoto);
            }
            else if (_estacionamento.VagasCarro.VagasDisponiveis > 0)
            {
                _estacionamento.VagasCarro.VagasDisponiveis--;
                _estacionamento.VagasCarro.VeiculosOcupantes.Add(new Moto());
                Console.WriteLine(Resource.msgMotoEstacionadaVagaCarro);
            }
            else if (_estacionamento.VagasVan.VagasDisponiveis > 0)
            {
                _estacionamento.VagasVan.VagasDisponiveis--;
                _estacionamento.VagasVan.VeiculosOcupantes.Add(new Moto());
                Console.WriteLine(Resource.msgMotoEstacionadaVagaVan);
            }
            else
                Console.WriteLine(Resource.msgNaoHaVagasMoto);

            if (_estacionamento.EstacionamentoCheio())
                Console.WriteLine(Resource.msgEstacinamentoCheio);

            LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
        }

        public void RetirarVeiculoServico()
        {
            if(_estacionamento.VagasVan.VeiculosOcupantes.Any(veiculo => veiculo is Moto))
            {
                Veiculo motoToRemove = _estacionamento.VagasVan.VeiculosOcupantes.First(veiculo => veiculo is Moto);
                _estacionamento.VagasVan.VeiculosOcupantes.Remove(motoToRemove);
                _estacionamento.VagasVan.VagasDisponiveis++;
                Console.WriteLine(Resource.msgMotoRetiradaVagaVan);
            }
            else if (_estacionamento.VagasCarro.VeiculosOcupantes.Any(veiculo => veiculo is Moto))
            {
                Veiculo motoToRemove = _estacionamento.VagasCarro.VeiculosOcupantes.First(veiculo => veiculo is Moto);
                _estacionamento.VagasCarro.VeiculosOcupantes.Remove(motoToRemove);
                _estacionamento.VagasCarro.VagasDisponiveis++;
                Console.WriteLine(Resource.msgMotoRetiradaVagaCarro);
            }
            else if (_estacionamento.VagasMoto.VeiculosOcupantes.Any(veiculo => veiculo is Moto))
            {
                Veiculo motoToRemove = _estacionamento.VagasMoto.VeiculosOcupantes.First(veiculo => veiculo is Moto);
                _estacionamento.VagasMoto.VeiculosOcupantes.Remove(motoToRemove);
                _estacionamento.VagasMoto.VagasDisponiveis++;
                Console.WriteLine(Resource.msgMotoRetiradaVagaMoto);
            }
            else
            {
                Console.WriteLine(Resource.msgNaoHaMotoParaRetirar);
            }

            LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
        }
    }
}
