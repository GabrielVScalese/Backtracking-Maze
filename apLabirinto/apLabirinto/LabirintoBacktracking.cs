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
            setMatriz(nomeArquivo);
        }

        private void setMatriz(string nomeArquivo)
        {
            var arquivo = new StreamReader(nomeArquivo);
            Colunas = int.Parse(arquivo.ReadLine());
            Linhas = int.Parse(arquivo.ReadLine());
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

        public int Linhas
        {
            get => linhas;
            set
            {
                if (value == null)
                    throw new Exception("Valor inválido");

                linhas = value;
            }
        }

        public int Colunas
        {
            get => colunas;
            set
            {
                if (value == null)
                    throw new Exception("Valor invalido");

                colunas = value;
            }
        }

        public string NomeArquivo
        {
            get => nomeArquivo;
            set
            {
                if (value == null || value.Equals(""))
                    throw new Exception("Nome do arquivo inválido");

                nomeArquivo = value;
            }
        }

        public PilhaLista<PilhaLista<Movimento>> BuscarCaminho(DataGridView dgvLab, ref PilhaLista<PilhaLista<Movimento>> caminhos, PilhaLista<Movimento> umCaminho)
        {
            int linhaAtual, colunaAtual;
            linhaAtual = colunaAtual = 1;
            int direcao = 0;


            PilhaLista<Movimento> aux = new PilhaLista<Movimento>();

            //ExibirPasso(dgvLab, colunaAtual, linhaAtual, "I");

            if (caminhos.GetQtd() > 0)
            {
                aux = (PilhaLista<Movimento>)umCaminho.Clone();
                aux.Desimpilhar();
                linhaAtual = aux.Topo.Linha;
                colunaAtual = aux.Topo.Coluna;
                direcao = aux.Topo.Direcao + 1;
                aux.Desimpilhar();
            }

            for (; ; )
            {
                bool encontrou = false;
                var posicaoEncontrada = VerificarLados(ref encontrou, direcao);
                if (encontrou)
                {
                    aux.Empilhar(new Movimento(linhaAtual, colunaAtual, posicaoEncontrada.Direcao));

                    matriz[linhaAtual, colunaAtual] = (char)111;
                    linhaAtual = posicaoEncontrada.Linha;
                    colunaAtual = posicaoEncontrada.Coluna;
                    direcao = 0;

                    if (matriz[linhaAtual, colunaAtual] == 83)
                    {
                        if (EhCaminhoDiferente(aux, caminhos))
                        {
                            //ExibirPasso(dgvLab, colunaAtual, linhaAtual, "S");
                            aux.Empilhar(new Movimento(linhaAtual, colunaAtual, posicaoEncontrada.Direcao));
                            PilhaLista<Movimento> caminhoEncontrado = (PilhaLista<Movimento>)aux.Clone();
                            caminhos.Empilhar(caminhoEncontrado);
                            BuscarCaminho(dgvLab, ref caminhos, caminhoEncontrado);
                            return caminhos;
                        }
                    }

                    //ExibirPasso(dgvLab, colunaAtual, linhaAtual, "o");
                    //return aux;
                    //continue;
                }
                else
                {
                    if (linhaAtual == 1 && colunaAtual == 1)
                    {
                        if (VerificarLados(ref encontrou, direcao) == null)
                            return caminhos;
                    }

                    Movimento posicaoAnterior = aux.Desimpilhar();
                    if (caminhos.GetQtd() > 0)
                         matriz[linhaAtual, colunaAtual] = (char)32; // Espaço

                    direcao = posicaoAnterior.Direcao + 1;
                    linhaAtual = posicaoAnterior.Linha;
                    colunaAtual = posicaoAnterior.Coluna;

                    //ExibirPasso(dgvLab, colunaAtual, linhaAtual, " ");
                }
            }

            Movimento VerificarLados(ref bool encontrado, int indice) // Circular
            {
                Movimento ret = null;
                int[] linha = new int[] {-1, -1, 0, 1, 1, 1, 0, -1};
                int[] coluna = new int[] { 0, 1, 1, 1, 0, -1,-1,-1};
                for (; indice < 8; indice++)
                     if (isFree(linha[indice], coluna[indice]))
                     {
                        encontrado = true;
                        ret = new Movimento(linhaAtual + linha[indice], colunaAtual + coluna[indice], indice);
                        break;
                     }

                return ret;
            }

            bool isFree(int somaLinha, int somaColuna)
            {
                if ((int)matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] != 35)
                    if ((int)matriz[linhaAtual + somaLinha, colunaAtual + somaColuna] != 111)
                        return true;

                return false;
            }

            bool EhCaminhoDiferente(PilhaLista<Movimento> solucaoEncontrado, PilhaLista<PilhaLista<Movimento>> solucoes)
            {
                NoLista<PilhaLista<Movimento>> aux1 = solucoes.Inicio;
                while (aux1 != null)
                {
                    if (aux1.Equals(solucaoEncontrado))
                        return false;

                    aux1 = aux1.Prox;
                }

                return true;
            }


            void ExibirPasso(DataGridView dgv, int coluna, int linha, string caracter)
            { 
                dgv[coluna, linha].Style.BackColor = Color.Green;
                dgv.CurrentCell = dgv[coluna, linha];
                dgv.Refresh();
                Thread.Sleep(500);
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
       
        public Object Clone()
        {
            LabirintoBacktracking ret = null;
            try
            {
                ret = new LabirintoBacktracking(this);
            }
            catch (Exception e)
            { }

            return ret;
        }

        public LabirintoBacktracking (LabirintoBacktracking modelo)
        {
            if (modelo == null)
                throw new Exception("Modelo ausente");

            Linhas = modelo.Linhas;
            Colunas = modelo.Colunas;
            NomeArquivo = modelo.NomeArquivo;
            setMatriz(NomeArquivo);
        }
    }
}
