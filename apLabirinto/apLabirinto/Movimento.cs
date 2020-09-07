using System;
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
        private int direcao;

        public Movimento(int linha, int coluna, int direcao)
        {
            Linha = linha;
            Coluna = coluna;
            Direcao = direcao;
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

        public int Direcao
        {
            get => direcao;
            set
            {
                if (direcao < 0)
                    throw new Exception("Direcao invalida");

                direcao = value;
            }
        }

        public int CompareTo (Movimento obj)
        {
            return 0;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;

            if (this == obj)
                return true;

            if (!GetType().Equals(obj.GetType()))
                return false;

            Movimento mov = (Movimento)obj;

            if (Linha != mov.Linha)
                return false;

            if (Coluna != mov.Coluna)
                return false;

            if (Direcao != mov.Direcao)
                return false;

            return true;
        }

        public override string ToString()
        {
            return "L: " + linha + " | C: " + coluna;
        }
    }
}
