using EstacionamentoApp.Enums;
using EstacionamentoApp.Model;
using EstacionamentoApp.Service;
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
                _estacionamento.ImprimirLogQuantidadeVagasEstacionamentoPossui();
                _estacionamento.ImprimirLogStatusEstacionamento();
                ImprimirMenuSelecao();
                int tipoServico = SelecionarServicoEstacionamento();

                var servicoEstacionamento = _selecionaServico.FabricarServicoEstacionamento((eTipoServicoEstacionamento) (tipoServico > 3 ? tipoServico -3 : tipoServico) );

                if (tipoServico < 4)
                    servicoEstacionamento.EstacionarVeiculoServico();
                else
                    servicoEstacionamento.RetirarVeiculoServico();

                _estacionamento.ImprimirLogVagasRestantesEstacionamento();
                continuar = SelecionarContinuidade();

            }
        }

        private static int SelecionarServicoEstacionamento()
        {
            Console.WriteLine("Digite o número do serviço desejado: ");
            int tipoServico = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return tipoServico;
        }

        private static bool SelecionarContinuidade()
        {
            bool continuar;
            Console.WriteLine("Deseja utilizar outro serviço? (1- Sim ou 2- Não)");
            int resp = Convert.ToInt32(Console.ReadLine());
            continuar = resp == 1;
            return continuar;
        }

        private void ImprimirMenuSelecao()
        {
            Console.WriteLine("\n------------------------------------------");
            Console.WriteLine("Selecione o tipo de serviço para o estacionamento:\n");
            Console.WriteLine("1 - Estacionar moto");
            Console.WriteLine("2 - Estacionar carro");
            Console.WriteLine("3 - Estacionar van");
            Console.WriteLine("4 - Retirar moto");
            Console.WriteLine("5 - Retirar carro");
            Console.WriteLine("6 - Retirar van");
            Console.WriteLine("------------------------------------------\n");
        }
    }
}
