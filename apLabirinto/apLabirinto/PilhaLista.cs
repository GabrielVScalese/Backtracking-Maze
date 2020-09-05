using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apLabirinto
{
    public class PilhaLista<Dado>
    {
        private ListaSimples<Dado> listaSimples;

        public PilhaLista()
        {
            listaSimples = new ListaSimples<Dado>();
        }

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

        public bool EstaVazia ()
        {
            if (listaSimples.GetQtd() == 0)
                return true;
            else
                return false;
        }

        public int GetQtd()
        {
            return listaSimples.GetQtd();
        }

        public NoLista<Dado> Inicio => listaSimples.Primeiro;

        public NoLista<Dado> Fim => listaSimples.Ultimo;

        public Dado Topo
        {
            get => listaSimples.GetUltimo();
        }

        public void PassarDados (PilhaLista<Dado> pilhaAux)
        {
            NoLista<Dado> aux = pilhaAux.listaSimples.Primeiro;
            while (aux != null)
            {
                listaSimples.InsiraNoFim(aux.Info);
                aux = aux.Prox;
            }
        }

        public Object Clone ()
        {
            PilhaLista<Dado> ret = null;
            try
            {
                ret = new PilhaLista<Dado>(this);
            }
            catch (Exception e)
            { }

            return ret;
        }

        public PilhaLista (PilhaLista<Dado> modelo)
        {
            if (modelo == null)
                throw new Exception("Modelo ausente");

            listaSimples = new ListaSimples<Dado>();
            NoLista<Dado> auxModelo = modelo.Inicio;
            while (auxModelo != null)
            {
                listaSimples.InsiraNoFim(auxModelo.Info);
                auxModelo = auxModelo.Prox;
            }
        }

        public override string ToString()
        {
            string ret = "{ ";
            NoLista<Dado> aux = Inicio;
            while (aux != null)
            {
                if (aux.Prox == null)
                    ret += aux.ToString();
                else
                    ret += aux.ToString() + ", ";

                aux = aux.Prox;
            }

            return ret + " }";
        }

        public override bool Equals (Object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (!GetType().Equals(obj.GetType()))
                return false;

            PilhaLista<Dado> pilha = (PilhaLista<Dado>)obj;

            if (GetQtd() != pilha.GetQtd())
                return false;

            NoLista<Dado> aux1 = pilha.Inicio;
            NoLista<Dado> aux2 = Inicio;
            while (aux1 != null)
            {
                if (!aux1.Info.Equals(aux2.Info))
                    return false;

                aux1 = aux1.Prox;
                aux2 = aux2.Prox;
            }

            return true;
        }
    }
}
