using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Ghost.Models
{
    public class ListaContexto : DbContext
    {
        public ListaContexto() : base("ListaContexto")
        {
            // Construtor que herda o contrutor base da DBContext e passa o nome da String de Conexão do BD contida no 
            //WEB.CONFIG para o contrutor base DbContext(string de conexão) da DbContext.
        }

        //incluindo as entidades do modelo
        public DbSet<Lista> Listas { get; set; }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Especificando configurações durante a criação do modelo de bd.
            //Neste caso o comando está Removendo o PluralizingTableNameConvention 
            //(Deixando as tabelas no Singular, sem S no final do nome delas).

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}