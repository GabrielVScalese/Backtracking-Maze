using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace apLabirinto
{
    public partial class Form1 : Form
    {
        private LabirintoBacktracking lab;
        private PilhaLista<PilhaLista<Movimento>> caminhos;
        private LabirintoBacktracking labClone;
        public Form1()
        {
            InitializeComponent();
        }

        private void btnArquivo_Click(object sender, EventArgs e)
        {
            if (dlgAbrir.ShowDialog() == DialogResult.OK)
            {
                lab = new LabirintoBacktracking(dlgAbrir.FileName);
                labClone = (LabirintoBacktracking)lab.Clone();

                dgvLabirinto.Rows.Clear();
                dgvLabirinto.Columns.Clear();
                lab.ExibirLabirinto(dgvLabirinto);
            }
        }

        private void btnEncontrar_Click(object sender, EventArgs e)
        {
            if (lab == null)
                MessageBox.Show("Escolha um arquivo!");
            else
            {
                lbCaminhos.Text = "Caminhos encontrados";
                dgvLabirinto.Rows.Clear();
                dgvLabirinto.Columns.Clear();
                labClone.ExibirLabirinto(dgvLabirinto);
                Thread.Sleep(500);
                caminhos = new PilhaLista<PilhaLista<Movimento>>();
                PilhaLista<Movimento> aux = new PilhaLista<Movimento>();
                caminhos = lab.BuscarCaminho(dgvLabirinto, ref caminhos, aux);
                dgvCaminhos.Rows.Clear();

                if (caminhos.GetQtd() > 0)
                {
                    MessageBox.Show("Saída encontrada! |" + " Nº de soluções: " + caminhos.GetQtd());
                    lbCaminhos.Text = "Caminhos encontrados: " + caminhos.GetQtd();
                }
                else
                    MessageBox.Show("Sem solução!");

                if (caminhos.GetQtd() > 0)
                    ExibirCaminhos();
            }
        }

        private void PrepararCaminhos ()
        {
            for (int lin = 0; lin < caminhos.GetQtd(); lin++)
            {
                dgvCaminhos.Rows[lin].HeaderCell.Value = $"{lin + 1}ª caminho";
            }
        }

        private void ExibirCaminhos ()
        {
            dgvCaminhos.RowCount = caminhos.GetQtd();
            dgvCaminhos.ColumnCount = 1;
            NoLista<PilhaLista<Movimento>> umCaminho = caminhos.Inicio;
            int i = 0;
            while (umCaminho != null)
            {
                dgvCaminhos[0, i].Value = umCaminho.Info.ToString();
                umCaminho = umCaminho.Prox;
                i++;
            }
            PrepararCaminhos();
        }

        private PilhaLista<Movimento> ObterUmCaminho (int indiceCaminho)
        {
            NoLista<PilhaLista<Movimento>> aux = caminhos.Inicio;
            labClone.ExibirLabirinto(dgvLabirinto);
            for (int i = 0; i < caminhos.GetQtd(); i++)
            {
                if (i == indiceCaminho)
                    return aux.Info;
                else
                    aux = aux.Prox;
            }

            return null;
        }

        private void ExibirUmCaminho (PilhaLista<Movimento> umCaminho)
        {
            NoLista<Movimento> aux = umCaminho.Inicio;
            while (aux != null)
            {                
                dgvLabirinto[aux.Info.Coluna, aux.Info.Linha].Style.BackColor = Color.Green;
                dgvLabirinto.CurrentCell = dgvLabirinto[aux.Info.Coluna, aux.Info.Linha];
                dgvLabirinto.Refresh();
                Thread.Sleep(800);
                aux = aux.Prox;
            }
        }

        private void dgvCaminhos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dgvLabirinto.Rows.Clear();
            dgvLabirinto.Columns.Clear();
            labClone.ExibirLabirinto(dgvLabirinto);
            var umCaminho = ObterUmCaminho(dgvCaminhos.SelectedCells[0].RowIndex);
            ExibirUmCaminho(umCaminho);
        }
    }
}
