using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization.Formatters;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apLabirinto
{
    public class LabirintoBacktracking
    {
        private char[,] matriz;
        private int linhas;
        private int colunas;
        string nomeArquivo;

        public LabirintoBacktracking(string nomeArquivo)
        {
            if (nomeArquivo == null || nomeArquivo.Equals(""))
                throw new Exception("Arquivo invalido");

            this.nomeArquivo = nomeArquivo;
            setMatriz();
        }

        private void setMatriz()
        {
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

        public PilhaLista<Movimento> BuscarCaminho(DataGridView dgvLab, ref PilhaLista<Movimento> possiveisCaminhos)
        {
            int linhaAtual, colunaAtual;
            linhaAtual = colunaAtual = 1;

            PilhaLista<Movimento> aux = new PilhaLista<Movimento>();

            ExibirSaida(dgvLab, colunaAtual, linhaAtual);

            for (; ; )
            {
                bool encontrou = false;
                var posicaoEncontrada = VerificarLados(ref encontrou);
                if (encontrou)
                {
                    aux.Empilhar(new Movimento(linhaAtual, colunaAtual));

                    matriz[linhaAtual, colunaAtual] = (char)111;
                    linhaAtual = posicaoEncontrada.Linha;
                    colunaAtual = posicaoEncontrada.Coluna;

                    ExibirSaida(dgvLab, colunaAtual, linhaAtual);

                    if (matriz[linhaAtual, colunaAtual] == 83)
                        return aux;

                    continue;
                }
                else
                {
                    Movimento posicaoAnterior = aux.Desimpilhar();
                    matriz[linhaAtual, colunaAtual] = (char)111;

                    linhaAtual = posicaoAnterior.Linha;
                    colunaAtual = posicaoAnterior.Coluna;

                    ExibirSaida(dgvLab, colunaAtual, linhaAtual);

                    if (linhaAtual == 1 && colunaAtual == 1)
                       return aux;
                }
            }

            Movimento VerificarLados(ref bool encontrado)
            {
                for (int linha = -1; linha <= 1; linha++)
                    for (int coluna = -1; coluna <= 1; coluna++)
                    {
                        if (linha == 0 && coluna == 0)
                            continue;

                        encontrado = isFree(linha, coluna);
                        if (encontrado)
                            return new Movimento(linhaAtual + linha, colunaAtual + coluna);
                    }

                return null;
            }

            bool isFree(int somaLinha, int somaColuna)
            {
                if ((int)matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] != 35)
                    if ((int)matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] != 111)
                        return true;

                return false;
            }

            /*bool Mover(int somaLinha, int somaColuna, ref bool encontrado)
            {
                bool foi = false;

                if ((int)matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] != 35)
                {
                    if ((int)matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] != 111)
                    {
                        if (matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] == 83)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            pilhaLista.Empilhar(new Movimento(linhaAtual, colunaAtual));
                            linhaAtual += somaLinha;
                            colunaAtual += somaColuna;
                            ExibirSaida(dgvLab, colunaAtual, linhaAtual);
                            encontrado = true;
                            foi = true;
                        }
                        else
                        {
                            pilhaLista.Empilhar(new Movimento(linhaAtual, colunaAtual));
                            matriz[linhaAtual, colunaAtual] = 'o';
                            linhaAtual += somaLinha;
                            colunaAtual += somaColuna;
                            foi = true;
                            cont = 0;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                        }
                    }
                }

                return foi;
            }*/

            void ExibirPasso(DataGridView dgv, int coluna, int linha)
            {
                dgv[coluna, linha].Value = "o";
                dgv.CurrentCell = dgv[coluna, linha];
                dgv.Refresh();
                Thread.Sleep(1000);
            }

            void ExibirSaida(DataGridView dgv, int coluna, int linha)
            {
                dgv.CurrentCell = dgv[coluna, linha];
                dgv.Refresh();
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

            dgv.CurrentCell = dgv[1, 1];
            dgv.Refresh();
        }
        public void ExibirCaminho (DataGridView dgvCaminhos, PilhaLista<Movimento> pilhaLista)
        {
            dgvCaminhos.RowCount = linhas;
            dgvCaminhos.ColumnCount = colunas;

            for (int lin = 0; lin < linhas; lin++)
                dgvCaminhos.Rows[lin].HeaderCell.Value = lin.ToString();

            for (int col = 0; col < colunas; col++)
                dgvCaminhos.Columns[col].HeaderText = col.ToString();

            NoLista<Movimento> aux = pilhaLista.Inicio;
            while (aux != null)
            {
                dgvCaminhos[aux.Info.Coluna, aux.Info.Linha].Value = "o";
                dgvCaminhos.Refresh();
                aux = aux.Prox;
            }
        }
    }
}
