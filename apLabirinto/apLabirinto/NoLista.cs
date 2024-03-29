﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apLabirinto
{
    public class NoLista<Dado>
    {
        private Dado dado;
        private NoLista<Dado> prox;

        public NoLista(Dado dado, NoLista<Dado> prox)
        {
            Info = dado;
            Prox = prox;
        }

        public Dado Info
        {
            get => dado;
            set
            {
                if (value == null)
                    throw new Exception("Informacao ausente");

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

        public override string ToString()
        {
            return dado.ToString();
        }
    }
}
