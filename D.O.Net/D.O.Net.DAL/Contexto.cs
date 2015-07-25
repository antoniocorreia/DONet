using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using D.O.Net.Entidades;

namespace D.O.Net.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuario> Usuario {get;set;}
        public DbSet<Interesse> Interesse {get;set;}
        public DbSet<Tag> Tag { get; set; }

        public Contexto(): base("DefaultConnection")
        {
            var a = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }
    }
}
