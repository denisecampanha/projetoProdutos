using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFornecedores.Classes
{
    public class FornecedoresRepositorio
    {
        public DataTable BuscarTodosFornecedores()
        {

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM FORNECEDORES";

            DataTable dt = _dataAccess.ExecutaConsulta(strSql);

            return dt;

        }

        public DataTable BuscarFornecedorPorNome(string strParteNome)
        {

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM FORNECEDORES WHERE NOME LIKE '%({strParteNome})%' ";

            DataTable dt = _dataAccess.ExecutaConsulta(strSql);

            return dt;

        }

        public bool Inserir(Fornecedores fornecedor)
        {
            bool bRetorno = false;
  
            DataAccess _dataAccess = new DataAccess();

            string strSql = $"INSERT INTO FORNECEDORES (ID, NOME, CNPJ, ENDERECO, ATIVO) VALUES (0,'{fornecedor.Nome}', '{fornecedor.CNPJ}','{fornecedor.Endereco}','{fornecedor.Ativo}') ";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public bool Atualizar(Fornecedores fornecedor)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"UPDATE FORNECEDORES SET NOME ='{fornecedor.Nome}' AND ENDERECO = '{fornecedor.Endereco}' AND ATIVO = '{fornecedor.Ativo}' WHERE CNPJ = '{fornecedor.CNPJ}'";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public bool Excluir(Fornecedores fornecedor)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"DELETE FROM FORNECEDORES WHERE CNPJ = '{fornecedor.CNPJ}' ";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public bool Existe(Fornecedores fornecedor)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM FORNECEDORES WHERE CNPJ = '{fornecedor.CNPJ}' ";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public DataTable FornecedoresAtivos()
        {

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT ID, NOME FROM FORNECEDORES WHERE ATIVO = 1 ";

            DataTable dt = _dataAccess.ExecutaConsulta(strSql);

            return dt;

        }

    }
}
