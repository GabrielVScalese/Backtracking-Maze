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
        }
    }
}
