﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace apLabirinto
{
    public class Movimento : IComparable<Movimento>
    {
        private int linha;
        private int coluna;


        public Movimento(int linha, int coluna)
        {
            Linha = linha;
            Coluna = coluna;
        }

        public int Linha
        {
            get => linha;
            set
            {
                if (value < 0)
                    throw new Exception("Linha invalida");

                linha = value;
            }
        }

        public int Coluna
        {
            get => coluna;
            set
            {
                if (coluna < 0)
                    throw new Exception("Coluna invalida");

                coluna = value;
            }
        }

        public int CompareTo (Movimento obj)
        {
            return 0;
        }

        public override string ToString()
        {
            return "L: " + linha + " C: " + coluna;
        }
    }
}