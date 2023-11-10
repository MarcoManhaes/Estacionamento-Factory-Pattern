using EstacionamentoApp.Enums;
using EstacionamentoApp.Factory;
using EstacionamentoApp.Interfaces;
using EstacionamentoApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Service
{
    public class SelecionaServico : ServicoEstacionamentoFactory
    {
        private readonly Estacionamento _estacionamento;

        public SelecionaServico(Estacionamento estacionamento)
        {
            _estacionamento = estacionamento;
        }

        public override IServicoEstacionamento FabricarServicoEstacionamento(eTipoServicoEstacionamento tiposServicos)
        {
            switch (tiposServicos)
            {
                case eTipoServicoEstacionamento.ServicoVan:
                    return new EstacionamentoVanServico(_estacionamento);
                case eTipoServicoEstacionamento.ServicoCarro:
                    return new EstacionamentoCarroServico(_estacionamento);
                case eTipoServicoEstacionamento.ServicoMoto:
                    return new EstacionamentoMotoServico(_estacionamento);
                default:
                    return null;
            }
        }
    }
}
