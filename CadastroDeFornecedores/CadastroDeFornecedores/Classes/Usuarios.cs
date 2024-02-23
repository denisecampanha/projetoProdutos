using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CadastroDeFornecedores.Classes
{
    public class Usuarios
    {
        public Usuarios()
        {

        }

        public Usuarios(int id, string login, string senha)
        {
            Id = id;
            Login = login;
            Senha = senha;
        }

        public int Id { get; set; }

        public string Login { get; set; }

        public string Senha { get; set; }
    }
}
