using CadastroDeFornecedores.Classes;
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
    public partial class frmProdutos : Form
    {
        #region Construtor
        public frmProdutos()
        {
            InitializeComponent();
            this.PopulaGrid();
            this.PopulaCombo();
         
        }

        #endregion

        #region Metodos

        private void PopulaGrid()
        {
            ProdutosRepositorio produtoRepositorio = new ProdutosRepositorio();

            DataTable dtProdutos = produtoRepositorio.BuscarTodosProdutos();

            grdPesquisaProduto.DataSource = dtProdutos;

        }

        private void PopulaCombo()
        {
            FornecedoresRepositorio fornecedoresRepositorio = new FornecedoresRepositorio();

            cboFornecedor.DataSource = fornecedoresRepositorio.FornecedoresAtivos();
            cboFornecedor.DisplayMember = "NOME";
            cboFornecedor.ValueMember = "ID";
            cboFornecedor.SelectedIndex = -1;

        }

        private void PesquisaProduto()
        {
            if (txtPesqProduto.Text != string.Empty)
            {
                ProdutosRepositorio produtosRepositorio = new ProdutosRepositorio();

                DataTable dtProdutos = produtosRepositorio.BuscarTodosProdutos();

                grdPesquisaProduto.DataSource = null;
                grdPesquisaProduto.DataSource = dtProdutos;
            }

        }

        private void DadosProduto(int index)
        {
            LimpaCadastro();
            tabControl1.SelectedTab = tabCadastro;

            DataGridViewRow selectedRow = grdPesquisaProduto.Rows[index];

            cboFornecedor.Text = selectedRow.Cells["FORNECEDOR"].Value.ToString();

            object valorQuantidade = grdPesquisaProduto.Rows[index].Cells["QUANTIDADE"].Value;
            lstQuantidade.Items.Add(valorQuantidade.ToString());
            lstQuantidade.SelectedItem = valorQuantidade.ToString();
        }

        private void SalvaProduto()
        {

            if (txtNome.Text != string.Empty && cboFornecedor.SelectedIndex != -1 && lstQuantidade.SelectedIndex != -1)
            {
                string strNome = txtNome.Text.Trim();
                string strFornecedor = cboFornecedor.Text.Trim();
                int intQuantidade = Convert.ToInt32(lstQuantidade.SelectedItem);

                var produto = new Produtos(0, strNome, strFornecedor, intQuantidade);

                var produtoRepositorio = new ProdutosRepositorio();

                if (produtoRepositorio.Existe(produto))
                {
                    produtoRepositorio.Atualizar(produto);
                }
                else
                {
                    produtoRepositorio.Inserir(produto);
                }
            }
            else
            {
                MessageBox.Show("Dados incompletos! Favor preencher todos os dados!");
            }
        }

        private void ExcluirProduto()
        {

            if (txtNome.Text != string.Empty && cboFornecedor.SelectedIndex != -1 && lstQuantidade.SelectedIndex != -1)
            {
                string strNome = txtNome.Text.Trim();
                string strFornecedor = cboFornecedor.Text.Trim();
                int intQuantidade = Convert.ToInt32(lstQuantidade.SelectedItem);

                var produto = new Produtos(0, strNome, strFornecedor, intQuantidade);

                var produtoRepositorio = new ProdutosRepositorio();

                produtoRepositorio.Excluir(produto);
            }
            else
            {
                MessageBox.Show("Dados incompletos! Favor preencher todos os dados!");
            }
        }

        private void LimpaCadastro()
        {
            txtNome.Text = string.Empty;
            cboFornecedor.SelectedIndex = -1;
            lstQuantidade.SelectedIndex = -1;
        }

        #endregion

        #region Eventos

        private void txtPesqFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PesquisaProduto();

                e.Handled = true;
            }
        }

        private void grdPesquisaProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void grdPesquisaProduto_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdPesquisaProduto.Rows.Count)
            {
                DadosProduto(e.RowIndex);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirProduto();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCadastro();
            tabControl1.SelectedTab = tabCadastro;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.SalvaProduto();
        }

        #endregion

    }
}
