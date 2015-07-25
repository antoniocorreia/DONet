namespace D.O.Net.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using D.O.Net.Entidades;

    internal sealed class Configuration : DbMigrationsConfiguration<D.O.Net.DAL.Contexto>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(D.O.Net.DAL.Contexto context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Tag.AddOrUpdate(t=>t.Descricao,
                new Tag { Descricao = "Concursos" },
                new Tag { Descricao = "Licitações" },
                new Tag { Descricao = "Atos" },
                new Tag { Descricao = "Decretos" },
                new Tag { Descricao = "Resoluções" },
                new Tag { Descricao = "Instruções normativas" },
                new Tag { Descricao = "Portarias" },
                new Tag { Descricao = "Contratos" },
                new Tag { Descricao = "Editais" },
                new Tag { Descricao = "Avisos ineditoriais" },
                new Tag { Descricao = "Balanços financeiros" }
                );
        }
    }
}
