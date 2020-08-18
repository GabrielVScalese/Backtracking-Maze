using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apLabirinto
{
    public class PilhaLista<Dado> where Dado : IComparable<Dado>
    {
        private ListaSimples<Dado> listaSimples;

        public void Empilhar (Dado dado)
        {
            listaSimples.InsiraNoFim(dado);
        }

        public Dado Desimpilhar ()
        {
            Dado dado = listaSimples.GetUltimo();
            listaSimples.RemovaDoFim();

            return dado;
        }

        public PilhaLista ()
        {
            listaSimples = new ListaSimples<Dado>();
        }
    }
}
