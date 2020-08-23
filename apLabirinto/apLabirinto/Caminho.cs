using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apLabirinto
{
    class Caminho
    {
        private PilhaLista<Movimento> posicoes;

        public Caminho()
        {
            this.posicoes = new PilhaLista<Movimento>();
        }

        public PilhaLista<Movimento> Posicoes { get => posicoes; set => posicoes = value; }
    }
}
