using EstacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Util
{
    public static class LogFluxoControleExecucao
    {
        public static void ConfiguirarEstacionamento(out int vagasMoto, out int vagasCarro, out int vagasVan)
        {
            Console.WriteLine(Resource.msgConfigurarEstacionamento);
            Console.WriteLine(Resource.msgObservacaoValidacoes);
            Console.WriteLine(Resource.msgQuantasVagasMotos);
            vagasMoto = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Resource.msgQuantasVagasCarros);
            vagasCarro = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Resource.msgQuantasVagasVans);
            vagasVan = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(Resource.msgQuantasVagasEstacionamento);
        }

        public static void ImprimirMenuSelecao()
        {
            Console.WriteLine("\n" + Resource.msgDivisao);
            Console.WriteLine(Resource.msgSelecioneTipoServico);
            Console.WriteLine(Resource.msgEstacionarMoto);
            Console.WriteLine(Resource.msgEstacionarCarro);
            Console.WriteLine(Resource.msgEstacionarVan);
            Console.WriteLine(Resource.msgRetirarMoto);
            Console.WriteLine(Resource.msgRetirarCarro);
            Console.WriteLine(Resource.msgRetirarVan);
            Console.WriteLine(Resource.msgDivisao + "\n");
        }

        public static bool SelecionarContinuidade()
        {
            bool continuar;
            Console.WriteLine(Resource.msgUtilizarOutroServico);
            int resp = Convert.ToInt32(Console.ReadLine());
            continuar = resp == 1;
            return continuar;
        }

        public static int SelecionarServicoEstacionamento()
        {
            Console.WriteLine(Resource.msgDigiteNumeroServico);
            int tipoServico = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            return tipoServico;
        }

        public static void ImprimirLogStatusEstacionamento(Estacionamento estacionamento)
        {
            Console.WriteLine(Resource.msgStatusEstacionamento);
            Console.WriteLine(string.Format(Resource.msgStatusVagasMoto, estacionamento.VagasMoto.VagasDisponiveis, estacionamento.VagasMoto.QuantidadeVagas));
            Console.WriteLine(string.Format(Resource.msgStatusVagasCarro, estacionamento.VagasCarro.VagasDisponiveis, estacionamento.VagasCarro.QuantidadeVagas));
            Console.WriteLine(string.Format(Resource.msgStatusVagasVan, estacionamento.VagasVan.VagasDisponiveis, estacionamento.VagasVan.QuantidadeVagas));

            if (estacionamento.EstacionamentoVazio())
                Console.WriteLine(Resource.msgEstacionamentoVazio);

            if (estacionamento.EstacionamentoCheio())
                Console.WriteLine(Resource.msgEstacionamentoVazio);

            Console.WriteLine(Resource.msgDivisao);
        }

        public static void ImprimirLogVagasRestantesEstacionamento(Estacionamento estacionamento)
        {
            Console.WriteLine(string.Format(Resource.msgRestamVagas, estacionamento.VagasTotaisDisponiveis()));
            Console.WriteLine(string.Format(Resource.msgVagasExclusivasMotos, estacionamento.VagasMoto.VagasDisponiveis) +
                              string.Format(Resource.msgVagasExclusivasCarros, estacionamento.VagasCarro.VagasDisponiveis) +
                              string.Format(Resource.msgVagasExclusivasVans, estacionamento.VagasVan.VagasDisponiveis));

            Console.WriteLine(Resource.msgDivisao + "\n");
        }

        public static void ImprimirLogQuantidadeVagasEstacionamentoPossui(Estacionamento estacionamento)
        {
            Console.WriteLine(string.Format(Resource.msgEstacionamentoPossuiTotal, estacionamento.TotalVagasEstacionamento()));
                Console.WriteLine(string.Format(Resource.msgVagasExclusivasMotos, estacionamento.VagasMoto.QuantidadeVagas) +
                                  string.Format(Resource.msgVagasExclusivasCarros, estacionamento.VagasCarro.QuantidadeVagas) +
                                  string.Format(Resource.msgVagasExclusivasVans, estacionamento.VagasVan.QuantidadeVagas));

            Console.WriteLine(Resource.msgDivisao + "\n");
        }
    }
}
