using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apLabirinto
{
    public class NoLista<Dado> where Dado : IComparable<Dado>
    {
        private Dado dado;
        private NoLista<Dado> prox;

        public Dado Info
        {
            get => dado;
            set
            {
                if (value != null)
                    dado = value;
            }
        }

        public NoLista<Dado> Prox
        {
            get => prox;
            set
            {
                prox = value;
            }
        }

        public NoLista (Dado dado, NoLista<Dado> prox)
        {
            Info = dado;
            Prox = prox;
        }
    }
}
