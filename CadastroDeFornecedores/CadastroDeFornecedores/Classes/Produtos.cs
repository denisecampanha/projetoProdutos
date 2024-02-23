using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFornecedores.Classes
{
    public class Produtos
    {
        public Produtos()
        {

        }
        public Produtos(int id, string nome, string fornecedor, int quantidade)
        {
            Id = id;
            Nome = nome;
            Fornecedor = fornecedor;
            Quantidade = quantidade;

        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Fornecedor { get; set; }

        public int Quantidade { get; set; }

    }
}
