using CadastroDeFornecedores.Classes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Data;

namespace CadastroDeFornecedores.Repositorios
{
    public class UsuariosRepositorio
    {
        public DataTable BuscarUsuarioPorLogin(string Login, string Senha)
        {
            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM USUARIOS WHERE LOGIN = ({Login}) AND SENHA = ({Senha})";

            DataTable dt = _dataAccess.ExecutaConsulta(strSql);

            return dt;

        }
    }
}
