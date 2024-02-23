using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CadastroDeFornecedores.Classes;
using CadastroDeFornecedores.Repositorios;

namespace CadastroDeFornecedores
{
    public partial class frmLogin : Form
    {
   
        #region Construtor
        public frmLogin()
        {
            InitializeComponent();
        }

        #endregion

        #region Métodos

        private bool ValidaSenha()
        {
            UsuariosRepositorio usuariosRepositorio = new UsuariosRepositorio();

            bool boOk = true; //alterado para testes,voltar

           /* if (txtUsuario.Text != string.Empty && txtSenha.Text != string.Empty)
            {

                DataTable resultado = usuariosRepositorio.BuscarUsuarioPorLogin(txtUsuario.Text, txtSenha.Text);

                if (resultado != null && resultado.Rows.Count > 0)
                {
                    boOk = true;
                }

                else
                {
                    MessageBox.Show("Login ou Senha inválido!");
                    boOk = false;
                }
            }

            else
            {
                MessageBox.Show("Campo Login ou Senha vazio!");
                boOk = false;
            }*/

            return boOk;
        }

        #endregion

        #region Eventos

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (ValidaSenha())
            { 
                frmSistema sistema = new frmSistema();

                sistema.Show();
            }

        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion
    }
}
