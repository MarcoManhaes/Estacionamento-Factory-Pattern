using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstacionamentoApp.Model
{
    public class Veiculo
    {
        public int Tamanho { get; private set; }

        public Veiculo(int tamanho)
        {
            Tamanho = tamanho;
        }
    }
}
