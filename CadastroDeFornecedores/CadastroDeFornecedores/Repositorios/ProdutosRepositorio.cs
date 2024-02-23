using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFornecedores.Classes
{
    public class ProdutosRepositorio
    {
        public DataTable BuscarTodosProdutos()
        {

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM PRODUTOS";

            DataTable dt = _dataAccess.ExecutaConsulta(strSql);

            return dt;

        }

        public DataTable BuscarFornecedorPorNome(string strParteNome)
        {

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM PRODUTOS WHERE NOME LIKE '%({strParteNome})%' ";

            DataTable dt = _dataAccess.ExecutaConsulta(strSql);

            return dt;

        }

        public bool Inserir(Produtos produto)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"INSERT INTO PRODUTOS (ID, NOME, FORNECEDOR, QUANTIDADE) VALUES (0,'{produto.Nome}', '{produto.Fornecedor}','{produto.Quantidade}') ";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public bool Atualizar(Produtos produto)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"UPDATE PRODUTOS SET FORNECEDOR ='{produto.Fornecedor}' AND QUANTIDADE = {produto.Quantidade} WHERE NOME = '{produto.Nome}'";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public bool Excluir(Produtos produto)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"DELETE FROM PRODUTOS WHERE  NOME = '{produto.Nome}'";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }

        public bool Existe(Produtos produto)
        {
            bool bRetorno = false;

            DataAccess _dataAccess = new DataAccess();

            string strSql = $"SELECT * FROM PRODUTOS WHERE  NOME = '{produto.Nome}'";

            int Rows = _dataAccess.ExecutaAtualizacao(strSql);

            bRetorno = Rows > 0 ? true : false;

            return bRetorno;
        }
    }
}
