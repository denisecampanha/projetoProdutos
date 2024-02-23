using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CadastroDeFornecedores
{
    public partial class frmSistema : Form
    {
        #region Construtor
        public frmSistema()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos

        #endregion

        #region Eventos

        private void fornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFornecedores frmFornec = new frmFornecedores();
            frmFornec.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmProdutos frmProd = new frmProdutos();
            frmProd.ShowDialog();
        }

        #endregion
    }
}
