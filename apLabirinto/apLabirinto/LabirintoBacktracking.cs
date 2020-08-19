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

        public LabirintoBacktracking(string nomeArquivo)
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

        public PilhaLista<Movimento> BuscarCaminho(DataGridView dgvLab, ref PilhaLista<Movimento> possiveisCaminhos)
        {
            int linhaSolucao = 0;
            int colunaSolucao = 0;
            int linhaAtual = 1;
            int colunaAtual = 1;
            PilhaLista<Movimento> pilhaLista = new PilhaLista<Movimento>();
            bool achou = false;
            int cont = 0;

            bool andou = false;

            if (possiveisCaminhos.EstaVazia() == false) // Ja achou um caminho
            {
                linhaAtual = possiveisCaminhos.Topo.Linha;
                colunaAtual = possiveisCaminhos.Topo.Coluna;
                pilhaLista.PassarDados(possiveisCaminhos);
                 for(; ; )
                {
                    andou = Mover(0, 1, ref achou); // Ir para direita
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(0, -1, ref achou); // Ir para esquerda
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(-1, 0, ref achou); // Ir para cima
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(1, 0, ref achou); // Ir para baixo
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(-1, 1, ref achou); // Ir para diagonal superior direita
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(-1, -1, ref achou); // Ir para diagonal superior esquerda
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(1, 1, ref achou); // Ir para diagonal inferior direita
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(1, -1, ref achou);  // Ir para diagonal inferior esquerda
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        pilhaLista = new PilhaLista<Movimento>();
                        BuscarCaminho(dgvLab, ref possiveisCaminhos);
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    if (linhaAtual == 1 && colunaAtual == 1)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista);
                        return pilhaLista;
                    }
                }
            }
            else
            {
                for(; ; )
                {
                    andou = Mover(0, 1, ref achou); // Ir para direita
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                            
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(0, -1, ref achou); // Ir para esquerda
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }

                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(-1, 0, ref achou); // Ir para cima
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(1, 0, ref achou); // Ir para baixo
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(-1, 1, ref achou); // Ir para diagonal superior direita
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(-1, -1, ref achou); // Ir para diagonal superior esquerda
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(1, 1, ref achou); // Ir para diagonal inferior direita
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    andou = Mover(1, -1, ref achou);  // Ir para diagonal inferior esquerda
                    if (achou == true)
                    {
                        possiveisCaminhos.PassarDados(pilhaLista); // ver marcacao fim
                        pilhaLista = new PilhaLista<Movimento>();
                        var aux = BuscarCaminho(dgvLab, ref possiveisCaminhos);
                        if (aux.EstaVazia() == true)
                        {
                            possiveisCaminhos.Empilhar(new Movimento(linhaSolucao, colunaSolucao));
                            return possiveisCaminhos;
                        }
                    }
                    if (andou == false)
                    {
                        if (cont == 8)
                        {
                            matriz[linhaAtual, colunaAtual] = 'o';
                            var mov = pilhaLista.Desimpilhar();
                            linhaAtual = mov.Linha;
                            colunaAtual = mov.Coluna;
                            ExibirPasso(dgvLab, colunaAtual, linhaAtual);
                            cont = 0;
                        }
                        else
                            cont++;
                    }

                    if (linhaAtual == 1 && colunaAtual == 1)
                    {
                        break;
                    }
                }

                return possiveisCaminhos;
            }

            bool Mover(int somaLinha, int somaColuna, ref bool encontrado)
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
                            linhaSolucao = linhaAtual;
                            colunaSolucao = colunaAtual;
                            ExibirSaida(dgvLab, colunaAtual, linhaAtual);
                            encontrado = true;
                            foi = true;
                            pilhaLista.Empilhar(new Movimento(linhaAtual, colunaAtual));

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
            }

            void ExibirPasso (DataGridView dgv, int coluna, int linha)
            {
                dgv[coluna, linha].Value = "o";
                dgv.CurrentCell = dgv[coluna, linha];
                dgv.Refresh();
                Thread.Sleep(1000);
            }

            void ExibirSaida (DataGridView dgv, int coluna, int linha)
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
