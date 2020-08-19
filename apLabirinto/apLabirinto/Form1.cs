using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apLabirinto
{
    public partial class Form1 : Form
    {
        LabirintoBacktracking lab;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                lab = new LabirintoBacktracking(dlgAbrir.FileName);

                lab.ExibirLabirinto(dgvLabirinto);
            }
        }

        private void btnEncontrar_Click(object sender, EventArgs e)
        {
            if (lab == null)
                MessageBox.Show("Escolha um arquivo!");

            PilhaLista<Movimento> caminhos = new PilhaLista<Movimento>();
            caminhos = lab.BuscarCaminho(dgvLabirinto, ref caminhos);
            dgvCaminhos.Rows.Clear();
            
            if (caminhos.EstaVazia() == false)
            {
                Movimento mov = caminhos.Topo;
                NoLista<Movimento> aux = caminhos.Inicio;
                int solucoes = 0;

                while (aux != null)
                {
                    if (aux.Info.Linha == mov.Linha && aux.Info.Coluna == mov.Coluna)
                        solucoes++;
                    else
                    {
                        aux = aux.Prox;
                    }

                    if (aux.Prox.Info.Linha.Equals(aux.Info.Linha) && aux.Prox.Info.Coluna.Equals(aux.Info.Coluna))
                    {
                        solucoes++;
                        break;
                    }
                }

                MessageBox.Show("Saída encontrada (" + mov + "), possibilidades: " + solucoes + "!");
            }
            else
                MessageBox.Show("Labirinto sem Saída");
        }
    }
}
