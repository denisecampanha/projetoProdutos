using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFornecedores.Classes
{
    public class Fornecedores
    {
        public Fornecedores()
        {

        }
        public Fornecedores(int id, string nome, string cnpj, string endereco, string ativo )
        {
            Id = id;
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Ativo = ativo;
       
        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public string CNPJ { get; set; }

        public string Endereco { get; set; }
        public string Ativo { get; set; }
    }
}
