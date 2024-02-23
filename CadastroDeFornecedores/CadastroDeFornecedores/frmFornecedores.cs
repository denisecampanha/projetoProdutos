using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroDeFornecedores.Classes;
using CadastroDeFornecedores.Repositorios;


namespace CadastroDeFornecedores
{
    public partial class frmFornecedores : Form
    {
        #region Construtor
        public frmFornecedores()
        {
            InitializeComponent();
            this.PopulaGrid();
        }

        #endregion

        #region Métodos

        /*private void CarregaGrid()
        {
            FornecedoresRepositorio fornecedoresRepositorio = new FornecedoresRepositorio();

            DataTable dt = fornecedoresRepositorio.BuscarTodosFornecedores();
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow regs in dt.Rows)
                {
                    grdPesquisaFornecedor.Rows.Add(!regs.IsNull("NOME") ? regs["NOME"].ToString() : "");
                    grdPesquisaFornecedor.Rows.Add(!regs.IsNull("CNPJ") ? regs["CNPJ"].ToString() : "");
                    grdPesquisaFornecedor.Rows.Add(!regs.IsNull("ENDERECO") ? regs["ENDERECO"].ToString() : "");
                    grdPesquisaFornecedor.Rows.Add(!regs.IsNull("ATIVO") ? regs["ATIVO"].ToString() : "");
                }
            }
        }*/

        private void PopulaGrid()
        {
            FornecedoresRepositorio fornecedoresRepositorio = new FornecedoresRepositorio();

            DataTable dtFornecedores = fornecedoresRepositorio.BuscarTodosFornecedores();

            grdPesquisaFornecedor.DataSource = dtFornecedores;

        }

        private void PesquisaFornec()
        {
            if (txtPesqFornecedor.Text != string.Empty)
            {
                FornecedoresRepositorio fornecedoresRepositorio = new FornecedoresRepositorio();

                DataTable dtFornecedores = fornecedoresRepositorio.BuscarTodosFornecedores();

                grdPesquisaFornecedor.DataSource = null;
                grdPesquisaFornecedor.DataSource = dtFornecedores;
            }
      
        }

        private void DadosFornecedor(int index)
        {
            LimpaCadastro();
            tabControl1.SelectedTab = tabCadastro;

            DataGridViewRow selectedRow = grdPesquisaFornecedor.Rows[index];

            string strAtivo = selectedRow.Cells["ATIVO"].Value.ToString();

            txtNome.Text = selectedRow.Cells["NOME"].Value.ToString();
            txtCNPJ.Text = selectedRow.Cells["CNPJ"].Value.ToString();
            txtNome.Text = selectedRow.Cells["ENDERECO"].Value.ToString();

            chkAtivo.Checked = strAtivo == "1" ? true : false;
        }

        private void SalvaFornecedor()
        {

            if (txtNome.Text != string.Empty && txtCNPJ.Text != string.Empty && txtEndereco.Text != string.Empty)
            {
                string strNome = txtNome.Text.Trim();
                string strCNPJ = txtCNPJ.Text.Trim();
                string strEndereco = txtEndereco.Text.Trim();
                string strAtivo = chkAtivo.Checked ? "1" : "0";

                var fornecedor = new Fornecedores(0, strNome, strCNPJ, strEndereco, strAtivo);

                var fornecedorRepositorio = new FornecedoresRepositorio();

                if (fornecedorRepositorio.Existe(fornecedor))
                {
                    fornecedorRepositorio.Atualizar(fornecedor);
                }
                else
                {
                    fornecedorRepositorio.Inserir(fornecedor);
                }
            }
            else
            {
                MessageBox.Show("Dados incompletos! Favor preencher todos os dados!");
            }
        }

        private void ExcluirFornecedor()
        {
            
            if (txtNome.Text != string.Empty && txtCNPJ.Text != string.Empty && txtEndereco.Text != string.Empty)
            {
                string strNome = txtNome.Text.Trim();
                string strCNPJ = txtCNPJ.Text.Trim();
                string strEndereco = txtEndereco.Text.Trim();
                string strAtivo = chkAtivo.Checked ? "1" : "0";

                var fornecedor = new Fornecedores(0, strNome, strCNPJ, strEndereco, strAtivo);

                var fornecedorRepositorio = new FornecedoresRepositorio();

                fornecedorRepositorio.Excluir(fornecedor);
            }
            else
            {
                MessageBox.Show("Dados incompletos! Favor preencher todos os dados!");
            }
        }

        private void LimpaCadastro()
        {
            txtNome.Text = string.Empty;
            txtCNPJ.Text = string.Empty;
            txtNome.Text = string.Empty;

            chkAtivo.Checked =  false;
        }

        #endregion

        #region Eventos

        private void txtPesqFornecedor_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                PesquisaFornec();

                e.Handled = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            ExcluirFornecedor();
        }

        private void grdPesquisaFornecedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < grdPesquisaFornecedor.Rows.Count)
            {
                DadosFornecedor(e.RowIndex);
            }

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            this.SalvaFornecedor();
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LimpaCadastro();
            tabControl1.SelectedTab = tabCadastro;
        }

        #endregion

    }
}
