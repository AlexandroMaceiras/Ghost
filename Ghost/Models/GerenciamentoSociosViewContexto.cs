namespace Ghost.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class GerenciamentoSociosViewContexto : DbContext
    {
        public GerenciamentoSociosViewContexto()
            : base("name=GerenciamentoSociosViewContexto")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
