﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apLabirinto
{
    public class PilhaLista<Dado> where Dado : IComparable<Dado>
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
    }
}
