using EstacionamentoApp.Enums;
using EstacionamentoApp.Model;
using EstacionamentoApp.Service;
using EstacionamentoApp.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp
{
    public class Client
    {
        private readonly SelecionaServico _selecionaServico;
        private readonly Estacionamento _estacionamento;

        public Client(SelecionaServico selecionaServico, Estacionamento estacionamento)
        {
            _selecionaServico = selecionaServico;
            _estacionamento = estacionamento;
        }

        public void ExecutaCriacaoServico()
        {
            var continuar = true;

            while (continuar)
            {
                LogFluxoControleExecucao.ImprimirLogQuantidadeVagasEstacionamentoPossui(_estacionamento);
                LogFluxoControleExecucao.ImprimirLogStatusEstacionamento(_estacionamento);
                LogFluxoControleExecucao.ImprimirMenuSelecao();
                int tipoServico = LogFluxoControleExecucao.SelecionarServicoEstacionamento();

                var servicoEstacionamento = _selecionaServico.FabricarServicoEstacionamento((eTipoServicoEstacionamento) (tipoServico > 3 ? tipoServico -3 : tipoServico) );

                if (tipoServico < 4)
                    servicoEstacionamento.EstacionarVeiculoServico();
                else
                    servicoEstacionamento.RetirarVeiculoServico();

                LogFluxoControleExecucao.ImprimirLogVagasRestantesEstacionamento(_estacionamento);
                continuar = LogFluxoControleExecucao.SelecionarContinuidade();
            }
        }
    }
}
