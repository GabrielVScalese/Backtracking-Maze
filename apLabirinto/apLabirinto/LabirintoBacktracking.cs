using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apLabirinto
{
    public class LabirintoBacktracking
    {
        private char[,] matriz;
        private int linhas;
        private int colunas;

        public LabirintoBacktracking (string nomeArquivo)
        {
            if (nomeArquivo == null || nomeArquivo.Equals(""))
                throw new Exception("Arquivo invalido");

            var arquivo = new StreamReader(nomeArquivo);
            colunas = int.Parse(arquivo.ReadLine());
            linhas = int.Parse(arquivo.ReadLine());
            matriz = new char[linhas, colunas];

            while (!arquivo.EndOfStream)
            {
                for (int lin = 0; lin < linhas; lin++)
                {
                    string linha = arquivo.ReadLine();
                    for (int col = 0; col < colunas; col++)
                        matriz[lin, col] = linha[col];
                }
            }
        }

        public void ExibirLabirinto (DataGridView dgv)
        {
            dgv.RowCount = linhas;
            dgv.ColumnCount = colunas;

            for (int lin = 0; lin < linhas; lin++)                     // Inicializando o DataGridView com os indices
                 dgv.Rows[lin].HeaderCell.Value = lin.ToString();
            
            for (int col = 0; col < colunas; col++)                    // Inicializando o DataGridView com os indices
                dgv.Columns[col].HeaderText = col.ToString();
            
            for (int lin = 0; lin < linhas; lin++)                    // Inicializando o DataGridView com os valores da matriz         
                 for (int col = 0; col < colunas; col++)
                    dgv[col, lin].Value = matriz[lin, col];
        }
    }
}
