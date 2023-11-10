using EstacionamentoApp.Enums;
using EstacionamentoApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Factory
{
    public abstract class ServicoEstacionamentoFactory
    {
        public abstract IServicoEstacionamento FabricarServicoEstacionamento(eTipoServicoEstacionamento tipoServicoEstacionamento);
    }
}
