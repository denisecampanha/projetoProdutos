using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;
using System.Runtime.Remoting.Contexts;
using System.Security.Policy;
using System.Windows.Forms;

namespace CadastroDeFornecedores.Classes
{
    public class DataContext : DbContext
    {
        public DataContext() : base("name=DataContextConnectionString")
        {
        }

        public DbSet<DataContext> SeusModelos { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configurações de mapeamento das entidades
            base.OnModelCreating(modelBuilder);
        }

    }
}
