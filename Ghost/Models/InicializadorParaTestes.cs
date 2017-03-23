using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Ghost.Models
{
    public class InicializadorParaTestes : DropCreateDatabaseIfModelChanges<ListaContexto>
    {
        protected override void Seed(ListaContexto contexto)
        {
            var listas = new List<Lista>
            {
                new Lista { Nome = "Alexandro Teste 1", Cpf = "155689788-10", Rg = "19321123-8" },
                new Lista { Nome = "Alexandro Teste 2", Cpf = "123123333-30", Rg = "19232333-9" },
                new Lista { Nome = "Alexandro Teste 3", Cpf = "232465676-60", Rg = "17225661-0" }
            };

            listas.ForEach(x => contexto.Listas.Add(x));
            contexto.SaveChanges();

        }
    }
}